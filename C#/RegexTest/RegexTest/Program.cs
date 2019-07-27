using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\#\d";
            string input = "dsjcks dsdj #2 jdsjfksjdc";
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(input);
            int id = Convert.ToInt32(mc[0].ToString().Replace("#", ""));
            Console.WriteLine(id);
        }
    }
}
