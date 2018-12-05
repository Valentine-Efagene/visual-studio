using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                while (true)
                {
                    var a = 5;
                    Console.WriteLine(a);
                }
            }).Start();

            Console.ReadLine();
        }
    }
}
