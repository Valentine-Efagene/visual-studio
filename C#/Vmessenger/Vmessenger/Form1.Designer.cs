namespace SocketClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.submitBtn = new System.Windows.Forms.Button();
            this.connectCheckBox = new System.Windows.Forms.CheckBox();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createConnectionCheckBox = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.addrssTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chatHistoryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.serverBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.clientBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.listOfConnectedRichTextBox = new System.Windows.Forms.RichTextBox();
            this.connectedIPsLabel = new System.Windows.Forms.Label();
            this.clearChatButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.submitBtn.BackColor = System.Drawing.Color.Gray;
            this.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.Black;
            this.submitBtn.Location = new System.Drawing.Point(15, 188);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(47, 23);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Send";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // connectCheckBox
            // 
            this.connectCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectCheckBox.AutoSize = true;
            this.connectCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectCheckBox.Location = new System.Drawing.Point(207, 189);
            this.connectCheckBox.Name = "connectCheckBox";
            this.connectCheckBox.Size = new System.Drawing.Size(45, 17);
            this.connectCheckBox.TabIndex = 3;
            this.connectCheckBox.Text = "Join";
            this.toolTip1.SetToolTip(this.connectCheckBox, "Check to connect; uncheck to disconnect.");
            this.connectCheckBox.UseVisualStyleBackColor = true;
            this.connectCheckBox.CheckedChanged += new System.EventHandler(this.connectCheckBox_CheckedChanged);
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageRichTextBox.BackColor = System.Drawing.Color.Black;
            this.messageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageRichTextBox.ForeColor = System.Drawing.Color.Green;
            this.messageRichTextBox.Location = new System.Drawing.Point(15, 141);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(554, 41);
            this.messageRichTextBox.TabIndex = 5;
            this.messageRichTextBox.Text = "";
            this.toolTip1.SetToolTip(this.messageRichTextBox, "Type your message here, and press enter to send, or use the send button.");
            this.messageRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageRichTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status:";
            // 
            // createConnectionCheckBox
            // 
            this.createConnectionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createConnectionCheckBox.AutoSize = true;
            this.createConnectionCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createConnectionCheckBox.Location = new System.Drawing.Point(84, 189);
            this.createConnectionCheckBox.Name = "createConnectionCheckBox";
            this.createConnectionCheckBox.Size = new System.Drawing.Size(117, 17);
            this.createConnectionCheckBox.TabIndex = 7;
            this.createConnectionCheckBox.Text = "Create Connection.";
            this.toolTip1.SetToolTip(this.createConnectionCheckBox, "Check to create connection; uncheck to terminate connection");
            this.createConnectionCheckBox.UseVisualStyleBackColor = true;
            this.createConnectionCheckBox.CheckedChanged += new System.EventHandler(this.server_CheckedChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusLabel.Location = new System.Drawing.Point(58, 223);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 13);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "...";
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aboutButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(680, 223);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(22, 22);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.Text = "?";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // addrssTextBox
            // 
            this.addrssTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addrssTextBox.Location = new System.Drawing.Point(321, 188);
            this.addrssTextBox.Name = "addrssTextBox";
            this.addrssTextBox.Size = new System.Drawing.Size(100, 20);
            this.addrssTextBox.TabIndex = 10;
            this.toolTip1.SetToolTip(this.addrssTextBox, "IP address of your device if you want to create the connection, or of the serving" +
        " device if you want to join.");
            this.addrssTextBox.TextChanged += new System.EventHandler(this.addrssTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(257, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP Address";
            // 
            // chatHistoryRichTextBox
            // 
            this.chatHistoryRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatHistoryRichTextBox.BackColor = System.Drawing.Color.Black;
            this.chatHistoryRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatHistoryRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatHistoryRichTextBox.ForeColor = System.Drawing.Color.Green;
            this.chatHistoryRichTextBox.Location = new System.Drawing.Point(15, 24);
            this.chatHistoryRichTextBox.Name = "chatHistoryRichTextBox";
            this.chatHistoryRichTextBox.ReadOnly = true;
            this.chatHistoryRichTextBox.Size = new System.Drawing.Size(554, 111);
            this.chatHistoryRichTextBox.TabIndex = 12;
            this.chatHistoryRichTextBox.Text = "";
            this.toolTip1.SetToolTip(this.chatHistoryRichTextBox, "Your chat history shows up here.");
            // 
            // serverBackgroundWorker
            // 
            this.serverBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serverBackgroundWorker_DoWork);
            // 
            // clientBackgroundWorker
            // 
            this.clientBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.clientBackgroundWorker_DoWork);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(437, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.portTextBox.Location = new System.Drawing.Point(469, 189);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 14;
            this.portTextBox.Text = "12324";
            this.toolTip1.SetToolTip(this.portTextBox, "Port to communicate on.");
            // 
            // listOfConnectedRichTextBox
            // 
            this.listOfConnectedRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfConnectedRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listOfConnectedRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listOfConnectedRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.listOfConnectedRichTextBox.Location = new System.Drawing.Point(582, 25);
            this.listOfConnectedRichTextBox.Name = "listOfConnectedRichTextBox";
            this.listOfConnectedRichTextBox.ReadOnly = true;
            this.listOfConnectedRichTextBox.Size = new System.Drawing.Size(107, 178);
            this.listOfConnectedRichTextBox.TabIndex = 15;
            this.listOfConnectedRichTextBox.Text = "";
            // 
            // connectedIPsLabel
            // 
            this.connectedIPsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectedIPsLabel.AutoSize = true;
            this.connectedIPsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectedIPsLabel.Location = new System.Drawing.Point(579, 9);
            this.connectedIPsLabel.Name = "connectedIPsLabel";
            this.connectedIPsLabel.Size = new System.Drawing.Size(102, 13);
            this.connectedIPsLabel.TabIndex = 16;
            this.connectedIPsLabel.Text = "Connected devices:";
            // 
            // clearChatButton
            // 
            this.clearChatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearChatButton.Location = new System.Drawing.Point(321, 215);
            this.clearChatButton.Name = "clearChatButton";
            this.clearChatButton.Size = new System.Drawing.Size(75, 23);
            this.clearChatButton.TabIndex = 17;
            this.clearChatButton.Text = "Clear chat";
            this.toolTip1.SetToolTip(this.clearChatButton, "Clear the chat history box.");
            this.clearChatButton.UseVisualStyleBackColor = true;
            this.clearChatButton.Click += new System.EventHandler(this.clearChatButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(714, 257);
            this.Controls.Add(this.clearChatButton);
            this.Controls.Add(this.connectedIPsLabel);
            this.Controls.Add(this.listOfConnectedRichTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chatHistoryRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addrssTextBox);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.createConnectionCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageRichTextBox);
            this.Controls.Add(this.connectCheckBox);
            this.Controls.Add(this.submitBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(730, 296);
            this.Name = "Form1";
            this.Text = "Vmessenger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.CheckBox connectCheckBox;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox createConnectionCheckBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.TextBox addrssTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox chatHistoryRichTextBox;
        private System.ComponentModel.BackgroundWorker serverBackgroundWorker;
        private System.ComponentModel.BackgroundWorker clientBackgroundWorker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.RichTextBox listOfConnectedRichTextBox;
        private System.Windows.Forms.Label connectedIPsLabel;
        private System.Windows.Forms.Button clearChatButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

