﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "F:\\videos";
            Organiser o = new Organiser(str);
            Console.WriteLine(o.GetActiveWindowTitle());
        }
    }
}
