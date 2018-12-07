using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Program
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();
            Console.WriteLine();
            Console.WriteLine("Started.");
            while (true)
            {
                ClientWorking cw = new ClientWorking(server.AcceptTcpClient());
                new Thread(new ThreadStart(cw.DoSomethingWithClient)).Start();
            }
            server.Stop();
        }
    }

    class ClientWorking
    {
        private Stream ClientStream;
        private TcpClient Client;

        public ClientWorking(TcpClient Client)
        {
            this.Client = Client;
            ClientStream = Client.GetStream();
        }

        public void DoSomethingWithClient()
        {
            StreamWriter sw = new StreamWriter(ClientStream);
            StreamReader sr = new StreamReader(sw.BaseStream);
            sw.WriteLine("Hi. This is x2 TCP/IP easy-to-use server");
            sw.Flush();
            string data;
            try
            {
                while ((data = sr.ReadLine()) != "exit")
                {
                    sw.WriteLine(data);
                    sw.Flush();
                    Console.WriteLine(data);
                }
            }
            finally
            {
                sw.Close();
            }
        }
    }
}