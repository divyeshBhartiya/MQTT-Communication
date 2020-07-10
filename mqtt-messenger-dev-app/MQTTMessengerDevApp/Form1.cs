using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MqttLib;
using MqttLib.Core.Messages;
using System.Threading;
using MQTTMessengerDevApp.DataAccess;
using MQTTMessengerDevApp.DataSchema;
using Newtonsoft.Json;
using MQTTMessengerDevApp.MQTTDataTypes;

namespace MQTTMessengerDevApp
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bgw1;
        private BackgroundWorker bgw2;
        private BackgroundWorker bgw3;

        PublishArrivedArgs messageArgs = null;

        public Form1()
        {
            InitializeComponent();

            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.ComponentModel.BackgroundWorker();
            this.bgw3 = new System.ComponentModel.BackgroundWorker();

            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(
                this.bgw1_RunWorkerCompleted);
            this.bgw2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(
                this.bgw2_RunWorkerCompleted);
            this.bgw3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(
                this.bgw3_RunWorkerCompleted);
        }

        string connectionString = "tcp://localhost:1883"; //"tcp://206.123.56.3:1883";
        string clientId = "server";

        IMqtt client;

        #region BtnClicks
        private void button1_Click(object sender, EventArgs e)
        {
            OpenMqtt();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CloseMqtt();
        }
        private void PublishBtn_Click(object sender, EventArgs e)
        {
            MqttPayload payload = new MqttPayload(MessageTB.Text);

            PublishMqtt(TopicTB.Text, payload);
        }
        #endregion

        #region UIChanges
        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MqttStatusLabel.ForeColor = Color.Green;
            MqttStatusLabel.Text = "Connected @ " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        private void bgw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MqttStatusLabel.ForeColor = Color.Red;
            MqttStatusLabel.Text = "Disconnected @ " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        private void bgw3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MQTTLogTB.Text += "Received Message" + Environment.NewLine;
            MQTTLogTB.Text += "Topic: " + messageArgs.Topic + Environment.NewLine;
            MQTTLogTB.Text += "Payload: " + messageArgs.Payload + Environment.NewLine;
            MQTTLogTB.Text += Environment.NewLine;
        }
        #endregion

        #region MQTT
        private void OpenMqtt()
        {
            client = MqttClientFactory.CreateClient(connectionString, clientId);
            client.Connect(true);

            client.Connected += new ConnectionDelegate(client_Connected);
            client.ConnectionLost += new ConnectionDelegate(_client_ConnectionLost);
            client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
            client.Published += new CompleteDelegate(_client_Published);
        }
        private void RegisterSubscriptions()
        {
            //client.Subscribe("mqttmessenger/server/userconnected", QoS.BestEfforts);
            //client.Subscribe("mqttmessenger/server/getmessages", QoS.BestEfforts);
            //client.Subscribe("mqttmessenger/server/newmessage", QoS.BestEfforts);
            //client.Subscribe("mqttmessenger/bob/messagedump", QoS.BestEfforts);
            client.Subscribe("eebus/daenet/command", QoS.BestEfforts);
            client.Subscribe("eebus/daenet/telemetry", QoS.BestEfforts);
        }
        private void CloseMqtt()
        {
            client.Disconnect();
            bgw2.RunWorkerAsync();
        }
        private void PublishMqtt(string topic, MqttPayload payload)
        {
            client.Publish(topic, payload, QoS.BestEfforts, false);
        }

        #region Mqtt Callbacks
        private void client_Connected(object sender, EventArgs e)
        {
            this.bgw1.RunWorkerAsync();
            RegisterSubscriptions();
        }
        private void _client_ConnectionLost(object sender, EventArgs e)
        {
            this.bgw2.RunWorkerAsync();
        }
        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            HandleMessage(e);

            messageArgs = e;
            this.bgw3.RunWorkerAsync();

            return true;
        }
        private void _client_Published(object sender, CompleteArgs e)
        {
            
        }
        #endregion

        private void HandleMessage(PublishArrivedArgs e)
        {
            string messageAction = e.Topic.Split('/')[2];
            string topicPrefix = "mqttmessenger/";

            switch (messageAction)
            {
                case "userconnected":
                    {
                        string gmail = e.Payload.ToString();
                        //userconnected action - save this somewhere?
                        break;
                    }
                case "getmessages":
                    {
                        string gmail = e.Payload.ToString();
                        List<MQTTMessage> messages = MessageController.GetUnreadMessagesByGmail(gmail);

                        PublishMqtt(JsonConvert.SerializeObject(messages), topicPrefix + gmail + "/messagedump");
                        break;
                    }
                case "newmessage":
                    {
                        MQTTMessengerDevApp.DataSchema.Message message = new MQTTMessengerDevApp.DataSchema.Message();
                        JsonConvert.DeserializeAnonymousType<MQTTMessengerDevApp.DataSchema.Message>(e.Payload.ToString(), message);
                        MessageController.NewMessage(message);
                        //Send To The other Guy
                        break;
                    }
                case "telemetry":
                    {
                        //MQTTMessengerDevApp.DataSchema.Message message = new MQTTMessengerDevApp.DataSchema.Message();
                        //JsonConvert.DeserializeAnonymousType<MQTTMessengerDevApp.DataSchema.Message>(e.Payload.ToString(), message);
                        //MessageController.NewMessage(message);
                        ////Send To The other Guy
                        break;
                    }
            }
        }
        #endregion
    }
}
