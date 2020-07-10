namespace MQTTMessengerDevApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TopicTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MqttStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MQTTLogTB = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.MessageTB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TopicTB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.MqttStatusLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MQTTLogTB);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 425);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Publish";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.PublishBtn_Click);
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(306, 57);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(247, 331);
            this.MessageTB.TabIndex = 8;
            this.MessageTB.Text = resources.GetString("MessageTB.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message:";
            // 
            // TopicTB
            // 
            this.TopicTB.Location = new System.Drawing.Point(306, 30);
            this.TopicTB.Name = "TopicTB";
            this.TopicTB.Size = new System.Drawing.Size(247, 20);
            this.TopicTB.TabIndex = 6;
            this.TopicTB.Text = "mqttmessenger/bob/messagedump";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Topic: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(73, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MqttStatusLabel
            // 
            this.MqttStatusLabel.AutoSize = true;
            this.MqttStatusLabel.Location = new System.Drawing.Point(70, 33);
            this.MqttStatusLabel.Name = "MqttStatusLabel";
            this.MqttStatusLabel.Size = new System.Drawing.Size(37, 13);
            this.MqttStatusLabel.TabIndex = 2;
            this.MqttStatusLabel.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "MQTT";
            // 
            // MQTTLogTB
            // 
            this.MQTTLogTB.Location = new System.Drawing.Point(12, 107);
            this.MQTTLogTB.Multiline = true;
            this.MQTTLogTB.Name = "MQTTLogTB";
            this.MQTTLogTB.Size = new System.Drawing.Size(192, 313);
            this.MQTTLogTB.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 449);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "MQTTMessengerDevApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MqttStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MQTTLogTB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TopicTB;
        private System.Windows.Forms.Label label2;
    }
}

