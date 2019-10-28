using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tree
{
    class Program
    {
        public string Path(Node<string> category)
        {
            Stack<string> pathStack = new Stack<string>();

            while (category != null)
            {
                pathStack.Push(category.Data);
                category = category.Parent;
            }

            string[] path = pathStack.ToArray();
            pathStack = null;

            foreach (string s in path)
            {
                Console.WriteLine(s);
            }

            string p = @"C:\Users\valentyne\Desktop\test2";

            for (int i = 0; i < path.Length; i++)
            {
                p += "\\" + path[i];
            }

            return p;
        }

        static void Main(string[] args)
        {
            string directory = @"C:\Users\valentyne\Desktop\test2";
            string type = "txt";
            Program p = new Program();
            IEnumerable<string> files = null;

            files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + type + ")$"));

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
