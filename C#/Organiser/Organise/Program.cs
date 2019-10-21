using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Organiser;
using System.Runtime.InteropServices;

namespace Organise
{
    class Program
    {
        static void Main(string[] args)
        {
            Organiser.Organiser o = new Organiser.Organiser();
            string s = o.GetDirectory();
            System.IO.File.WriteAllText(@"C: \Users\valentyne\Desktop\log.txt", s);
            o.Organise();
        }
    }
}
