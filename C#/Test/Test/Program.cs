﻿using System;
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
            string pattern = @"\#\d";
            string input = "dsjcks dsdj #2 jdsjfksjdc";
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(input);
            
            foreach(Match m in mc)
            {
                Console.WriteLine(m);
            }
        }
    }
}
