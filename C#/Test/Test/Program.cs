﻿using System;
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
        public string pass;
        public string src = "Value";

        public void setPass(string target, string src)
        {
            target = src;
        }

        static void Main(string[] args)
        {
            Program test = new Program();
            Console.WriteLine(test.pass);
            Console.WriteLine(test.src);
        }
    }
}
