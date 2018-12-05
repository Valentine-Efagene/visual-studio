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
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.connectRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(238, 49);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(323, 20);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.TextChanged += new System.EventHandler(this.messageTextBox_TextChanged);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(362, 75);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // connectRadioButton
            // 
            this.connectRadioButton.AutoSize = true;
            this.connectRadioButton.Location = new System.Drawing.Point(436, 190);
            this.connectRadioButton.Name = "connectRadioButton";
            this.connectRadioButton.Size = new System.Drawing.Size(65, 17);
            this.connectRadioButton.TabIndex = 2;
            this.connectRadioButton.TabStop = true;
            this.connectRadioButton.Text = "Connect";
            this.connectRadioButton.UseVisualStyleBackColor = true;
            this.connectRadioButton.CheckedChanged += new System.EventHandler(this.connectRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectRadioButton);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.RadioButton connectRadioButton;
    }
}

