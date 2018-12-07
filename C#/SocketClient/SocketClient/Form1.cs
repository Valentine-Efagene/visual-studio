﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace SocketClient
{

    public partial class Form1 : Form
    {
        bool created = false;
        int connected = 0;
        NetworkStream stream = null;
        int port = 8080;
        TcpClient client = null;
        TcpListener server = null;

        public Form1()
        {
            InitializeComponent();
            clientBackgroundWorker.WorkerSupportsCancellation = true;
            serverBackgroundWorker.WorkerSupportsCancellation = true;
        }

        ~Form1()
        {
            if (server != null)
            {
                server.Stop();
            }

            if (client != null)
            {
                client.Close();
            }

            if (stream != null)
            {
                stream.Close();
            }
        }

        public RichTextBox getMessageRichTextBox()
        {
            return messageRichTextBox;
        }

        public RichTextBox getchatHistoryRichTextBox()
        {
            return chatHistoryRichTextBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(stream);
                StreamReader sr = new StreamReader(sw.BaseStream);
                sw.WriteLine(messageRichTextBox.Text);
                sw.Flush();
                chatHistoryRichTextBox.AppendText("Me: " + messageRichTextBox.Text + "\n");
                messageRichTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void messageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void connectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            connected++;

            if (connectCheckBox.Checked == true)
            {
                if (server != null)
                {
                    server.Stop();
                    stream.Close();
                }

                if (addrssTextBox.Text == "")
                {
                    connectCheckBox.Checked = false;
                    MessageBox.Show("Please enter an IP address.");
                    return;
                }
                else
                {
                    try
                    {
                        client = new TcpClient(addrssTextBox.Text.Trim(' '), port);
                        stream = client.GetStream();
                        clientBackgroundWorker.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("At connection creation line 122" + ex.ToString());
                    }
                }
            }
            else
            {
                if (connected > 0)
                {
                    clientBackgroundWorker.CancelAsync();
                    MessageBox.Show("You just terminated the connection");
                }

                if (client != null)
                {
                    client.Close();
                }

                if(stream != null)
                {
                    stream.Close();
                }
                
            }
        }

        private void messageRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void server_CheckedChanged(object sender, EventArgs e)
        {
            connectCheckBox.Checked = false;
            created = !created;

            if(created) {
                if (client != null)
                {
                    client.Close();
                    stream.Close();
                }

                serverBackgroundWorker.RunWorkerAsync();
            }
        }

        private void serverBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (addrssTextBox.Text == "")
            {
                createConnectionCheckBox.Checked = false;
                MessageBox.Show("Please enter an IP address.");
            }
            else
            {
                server = new TcpListener(IPAddress.Parse(addrssTextBox.Text.Trim(' ')), 8080);
            }
            server.Start();
            this.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "Connection created";
            });
            while (true)
            {
                try
                {
                    ClientWorking cw = new ClientWorking(this, server.AcceptTcpClient());
                    stream = (NetworkStream)cw.getStream();
                    new Thread(new ThreadStart(cw.DoSomethingWithClient)).Start();
                }catch(Exception ex)
                {
                    MessageBox.Show("At server background 189" + ex.ToString());
                }
            }
        }

        private void serverBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void serverBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void clientBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(sw.BaseStream);
            string data = null;

            try
            {
                while ((data = sr.ReadLine()) != "exit")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        chatHistoryRichTextBox.AppendText(data + "\n");
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string a = ex.ToString();
                    statusLabel.Text = "Connection terminated!";
                });
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app uses port 8080;" +
                "\n so, please leave alone. There are so many others for you to use." +
                "Developer:\n" +
                "Name: Valentine Edesiri Efagene\n" +
                "Whatsapp number: 07053229765" +
                "Mobile number: 09034360573" +
                "Nationality: Nigerian");
        }
    }

    class ClientWorking
    {
        private Stream ClientStream;
        private TcpClient Client;
        Form1 ui;

        public ClientWorking(Form1 ui, TcpClient Client)
        {
            this.Client = Client;
            ClientStream = Client.GetStream();
            this.ui = ui;
        }

        public Stream getStream()
        {
            return ClientStream;
        }

        public void DoSomethingWithClient()
        {
            StreamWriter sw = new StreamWriter(ClientStream);
            StreamReader sr = new StreamReader(sw.BaseStream);
            sw.Flush();
            string data;
            try
            {
                while ((data = sr.ReadLine()) != "")
                {
                    ui.Invoke((MethodInvoker) delegate
                    {
                        ui.getchatHistoryRichTextBox().AppendText(data + "\n");
                    });
                }
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
