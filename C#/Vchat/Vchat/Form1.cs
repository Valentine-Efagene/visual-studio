using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Vchat
{
    public partial class Form1 : Form
    {
        int r = 0;
        IPAddress ipAddress;
        IPEndPoint localEndPoint;
        // Incoming data from the client.  
        public static string data = null;
        // Data buffer for incoming data.  
        byte[] bytes = new Byte[1024];
        int port = 12345;

        public Form1()
        {
            InitializeComponent();
        }

        ~Form1()
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roleBtn_Click(object sender, EventArgs e)
        {
            r++;

            if (r % 2 == 0)
            {
                roleBtn.Text = "SERVER";
            }
            else
            {
                roleBtn.Text = "CLIENT";
            }
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (roleBtn.Text == "SERVER")
            {
                ipAddress = IPAddress.Parse(addressTextBox.Text);

                if(! Int32.TryParse(addressTextBox.Text, out port) )
                {
                    MessageBox.Show("Could not parse port!");
                }

                localEndPoint = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and   
                // listen for incoming connections.  
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    // Start listening for connections.  
                    while (true)
                    {
                        chatRichTextBox.Text = "Waiting for a connection...";
                        // Program is suspended while waiting for an incoming connection.  
                        Socket handler = listener.Accept();
                        data = null;

                        // An incoming connection needs to be processed.  
                        while (true)
                        {
                            int bytesRec = handler.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            if (data.IndexOf("<EOF>") > -1)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                ipAddress = IPAddress.Parse(addressTextBox.Text);

                if (!Int32.TryParse(addressTextBox.Text, out port))
                {
                    MessageBox.Show("Could not parse port!");
                }
            }
        }
    }
}
