using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;

namespace SocketClient
{

    public partial class Form1 : Form
    {
        List<string> connectedIPs = new List<string>();
        int created = 0;
        int connected = 0;
        NetworkStream stream = null;
        int port = 12324;
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

        public BackgroundWorker getserverBackgroundWorker()
        {
            return serverBackgroundWorker;
        }

        public List<string> getConnectedIPs()
        {
            return connectedIPs;
        }

        public RichTextBox getConnectedIPsRichTextBox()
        {
            return listOfConnectedRichTextBox;
        }

        public RichTextBox getMessageRichTextBox()
        {
            return messageRichTextBox;
        }

        public Label getStatusLabel()
        {
            return statusLabel;
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
            send();
        }

        private void send()
        {
            try
            {
                StreamWriter sw = new StreamWriter(stream);
                StreamReader sr = new StreamReader(sw.BaseStream);
                sw.WriteLine(messageRichTextBox.Text);
                sw.Flush();
                chatHistoryRichTextBox.AppendText("Me: \n" + messageRichTextBox.Text + "\n\n");
                chatHistoryRichTextBox.ScrollToCaret();
                messageRichTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("You are not connected to the intended recipient.");
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

            try
            {
                port = Convert.ToInt32(portTextBox.Text.Trim(' '));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter an integer value.");
            }

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
                        
                        if(client != null)
                        {
                            listOfConnectedRichTextBox.AppendText(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + "\n");
                            stream = client.GetStream();
                            clientBackgroundWorker.RunWorkerAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Line 123 " + ex.ToString());
                    }
                }
            }
            else
            {
                if (connected > 0)
                {
                    clientBackgroundWorker.CancelAsync();
                    statusLabel.Text = "Connection to " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " terminated";
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

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void server_CheckedChanged(object sender, EventArgs e)
        {
            created++;

            if(createConnectionCheckBox.Checked == true)
            {
                try
                {
                    Convert.ToInt32(portTextBox.Text.Trim(' '));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter an integer value.");
                    createConnectionCheckBox.Checked = false;
                    return;
                }

                if (addrssTextBox.Text == "")
                {
                    createConnectionCheckBox.Checked = false;
                    MessageBox.Show("Please enter an IP address.");
                    return;
                }
                else
                {
                    server = new TcpListener(IPAddress.Parse(addrssTextBox.Text.Trim(' ')), port);
                }

                server.Start();

                try
                {
                    if (serverBackgroundWorker.IsBusy)
                    {
                        MessageBox.Show("server background task is still running!");
                    }
                    else
                    {
                        serverBackgroundWorker.RunWorkerAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }else
            {
                if (created > 0)
                {
                    serverBackgroundWorker.CancelAsync();
                    statusLabel.Text = "Connection terminated.";
                }

                if (client != null)
                {
                    client.Close();
                }

                if (stream != null)
                {
                    stream.Close();
                }

                if (server != null)
                {
                    server.Stop();
                }
            }
        }

        private void serverBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = "Connection created";
            });

            while (true)
            {
                if (serverBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    TcpClient c = server.AcceptTcpClient();
                    DialogResult res = MessageBox.Show("Do you want to allow " + ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString() +
                        " to join?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (!(res == DialogResult.Yes))
                    {
                        c.Close();
                        return;
                    }

                    ClientWorking cw = new ClientWorking(this, c);
                    stream = (NetworkStream)cw.getStream();

                    if (stream != null)
                    {
                        new Thread(new ThreadStart(cw.interact)).Start();
                        this.Invoke((MethodInvoker)delegate
                        {
                            statusLabel.Text = ((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString() + " has joined.";
                            connectedIPs.Add(((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString());
                            listOfConnectedRichTextBox.AppendText(((IPEndPoint)c.Client.RemoteEndPoint).Address.ToString() + "\n");
                        });
                    }
                }catch(Exception ex)
                {
                    serverBackgroundWorker.CancelAsync();
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
            if (stream != null)
            {
                statusLabel.Text = "Connected to " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + ".";
            }

            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(sw.BaseStream);
            string data = null;

            //REMOVE LATER
            while (true)
            {
                sw = new StreamWriter(stream);
                sw.WriteLine("1366 768");
                sw.Flush();
            }
            //ABOVE MUST BE REMOVED LATER

            try
            {
                while ((data = sr.ReadLine()) != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        chatHistoryRichTextBox.AppendText(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + ": \n" + data + "\n\n");
                        chatHistoryRichTextBox.ScrollToCaret();
                    });
                }

                statusLabel.Text = "Connection to " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " rejected!";
                listOfConnectedRichTextBox.Text = "";
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string a = ex.ToString();
                    statusLabel.Text = "Connection to " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + " terminated";
                    listOfConnectedRichTextBox.Text = "";
                });
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About App:\nThis app uses port 12324 as default, but you can change it to allow more connections.\n" +
                "\n\n" +
                "About Developer:\n" +
                "Name: Valentine Edesiri Efagene\n" +
                "Whatsapp number: 07053229765\n" +
                "Mobile number: 09034360573\n" +
                "Nationality: Nigerian");
        }

        private void addrssTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearChatButton_Click(object sender, EventArgs e)
        {
            chatHistoryRichTextBox.Text = "";
        }

        private void messageRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                send();
            }
        }

        private void messageRichTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

    class ClientWorking
    {
        private Stream clientStream;
        private TcpClient client;
        Form1 ui;
        private string clientIP;

        public ClientWorking(Form1 ui, TcpClient client)
        {
            this.client = client;
            clientStream = client.GetStream();
            this.ui = ui;
            clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
        }

        public Stream getStream()
        {
            return clientStream;
        }

        public void interact()
        {
            if(clientStream == null)
            {
                MessageBox.Show("OK");
            }

            StreamWriter sw = new StreamWriter(clientStream);
            StreamReader sr = new StreamReader(sw.BaseStream);
            sw.Flush();
            string data;

            try
            {
                while ((data = sr.ReadLine()).Trim(' ') != "exit")
                {
                    ui.Invoke((MethodInvoker) delegate
                    {
                        ui.getchatHistoryRichTextBox().AppendText(clientIP + ": \n" + data + "\n\n");
                        ui.getchatHistoryRichTextBox().ScrollToCaret();
                    });
                }
            }
            catch (Exception ex)
            {
                client.Close();
                ui.Invoke((MethodInvoker)delegate
                {
                    string a = ex.ToString();
                    ui.getStatusLabel().Text = clientIP + " has left.";
                });

                ui.getConnectedIPs().Remove(clientIP);

                ui.getConnectedIPsRichTextBox().Text = "";

                foreach (string ip in ui.getConnectedIPs())
                {
                    ui.getConnectedIPsRichTextBox().AppendText(ip + "\n");
                }
            }
            finally
            {
                client.Close();
                sw.Close();
            }
        }
    }
}
