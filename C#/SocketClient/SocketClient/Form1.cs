using System;
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

namespace SocketClient
{

    public partial class Form1 : Form
    {
        NetworkStream stream = null;
        string serverIp = "localhost";
        int port = 8080;
        TcpClient client = null;

        public Form1()
        {
            InitializeComponent();
        }

        ~Form1()
        {
            client.Close();
            stream.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int byteCount = Encoding.ASCII.GetByteCount(messageTextBox.Text);
                byte[] sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(messageTextBox.Text);
                stream.Write(sendData, 0, sendData.Length);
                messageTextBox.Text = "";
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
            try
            {
                client = new TcpClient(serverIp, port);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
