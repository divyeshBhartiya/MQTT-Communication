using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MQTTMessengerDevApp.DataSchema;
using MQTTMessengerDevApp.MQTTDataTypes;

namespace MQTTMessengerDevApp.DataAccess
{
    public class MessageController
    {
        #region Write

        public static void NewMessage(Message message)
        {
            MessengerDataContext dc = new MessengerDataContext();
            dc.Messages.InsertOnSubmit(message);
            dc.SubmitChanges();
        }

        #endregion

        #region Read

        public static List<MQTTMessage> GetUnreadMessagesByGmail(string gmail)
        {
            MessengerDataContext dc = new MessengerDataContext();

            List<MQTTMessage> mqttMessageList = new List<MQTTMessage>();

            IQueryable<Message> messageList = from messages in dc.Messages
                                join users in dc.Users on
                                messages.ToID equals users.ID
                                where users.gmail == gmail &&
                                messages.SendingPending
                                select messages;
            foreach (Message message in messageList)
            {
                MQTTMessage mqttMessage = new MQTTMessage();
                mqttMessage.gmail = GetGmailByID(message.FromID);
                mqttMessage.message = message.Text;
                mqttMessage.time = message.Time.ToString();

                mqttMessageList.Add(mqttMessage);
            }

            return mqttMessageList;
        }

        public static string GetGmailByID(int id)
        {
            MessengerDataContext dc = new MessengerDataContext();

            return (from users in dc.Users
                    where users.ID == id
                    select users.gmail).Single();
        }

        #endregion
    }
}
