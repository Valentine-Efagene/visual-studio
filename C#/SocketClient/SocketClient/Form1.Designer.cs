﻿namespace SocketClient
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
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.submitBtn.BackColor = System.Drawing.Color.Gray;
            this.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.ForeColor = System.Drawing.Color.Black;
            this.submitBtn.Location = new System.Drawing.Point(12, 163);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(80, 23);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Send";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // connectCheckBox
            // 
            this.connectCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.connectCheckBox.AutoSize = true;
            this.connectCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectCheckBox.Location = new System.Drawing.Point(256, 167);
            this.connectCheckBox.Name = "connectCheckBox";
            this.connectCheckBox.Size = new System.Drawing.Size(45, 17);
            this.connectCheckBox.TabIndex = 3;
            this.connectCheckBox.Text = "Join";
            this.connectCheckBox.UseVisualStyleBackColor = true;
            this.connectCheckBox.CheckedChanged += new System.EventHandler(this.connectCheckBox_CheckedChanged);
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageRichTextBox.BackColor = System.Drawing.Color.Black;
            this.messageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageRichTextBox.ForeColor = System.Drawing.Color.Green;
            this.messageRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(638, 47);
            this.messageRichTextBox.TabIndex = 5;
            this.messageRichTextBox.Text = "";
            this.messageRichTextBox.TextChanged += new System.EventHandler(this.messageRichTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(487, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status:";
            // 
            // createConnectionCheckBox
            // 
            this.createConnectionCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.createConnectionCheckBox.AutoSize = true;
            this.createConnectionCheckBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.createConnectionCheckBox.Location = new System.Drawing.Point(107, 166);
            this.createConnectionCheckBox.Name = "createConnectionCheckBox";
            this.createConnectionCheckBox.Size = new System.Drawing.Size(114, 17);
            this.createConnectionCheckBox.TabIndex = 7;
            this.createConnectionCheckBox.Text = "Create Connection";
            this.createConnectionCheckBox.UseVisualStyleBackColor = true;
            this.createConnectionCheckBox.CheckedChanged += new System.EventHandler(this.server_CheckedChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusLabel.Location = new System.Drawing.Point(530, 170);
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
            this.aboutButton.Location = new System.Drawing.Point(627, 163);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(22, 22);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.Text = "?";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // addrssTextBox
            // 
            this.addrssTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addrssTextBox.Location = new System.Drawing.Point(367, 166);
            this.addrssTextBox.Name = "addrssTextBox";
            this.addrssTextBox.Size = new System.Drawing.Size(100, 20);
            this.addrssTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Address";
            // 
            // chatHistoryRichTextBox
            // 
            this.chatHistoryRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatHistoryRichTextBox.Location = new System.Drawing.Point(12, 61);
            this.chatHistoryRichTextBox.Name = "chatHistoryRichTextBox";
            this.chatHistoryRichTextBox.ReadOnly = true;
            this.chatHistoryRichTextBox.Size = new System.Drawing.Size(638, 96);
            this.chatHistoryRichTextBox.TabIndex = 12;
            this.chatHistoryRichTextBox.Text = "";
            // 
            // serverBackgroundWorker
            // 
            this.serverBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serverBackgroundWorker_DoWork);
            // 
            // clientBackgroundWorker
            // 
            this.clientBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.clientBackgroundWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(662, 192);
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
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

