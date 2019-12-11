#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Trees;
#endregion

namespace FileSystemTree
{
    class Program
    {
        Dictionary<string, bool> mVisited = new Dictionary<string, bool>();

        void FillInKids(Node<string> rhs)
        {
            string path = rhs.Data;

            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);

                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    mVisited.Add(d.FullName, false);
                    Node<string> kid = new Node<string>(d.FullName);
                    rhs.Children.Add(kid);
                    this.FillInKids(kid);
                }

                foreach (FileInfo f in di.GetFiles())
                {
                    mVisited.Add(f.FullName, false);
                    rhs.Children.Add(new Node<string>(f.FullName));
                }
            }
        }

        string[] GetFilenames()
        {
            string[] keys = new string[mVisited.Keys.Count];
            mVisited.Keys.CopyTo(keys, 0);
            return keys;
        }

        void ResetVisited()
        {
            string[] keys = this.GetFilenames();

            foreach (string k in keys)
                mVisited[k] = false;
        }

        void AssertAllVisited()
        {
            string[] keys = this.GetFilenames();

            foreach (string k in keys)
                Debug.Assert(mVisited[k]);
        }

        void Iterate(IEnumerator<string> iterator)
        {
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
                mVisited[iterator.Current] = true;
            }

            this.AssertAllVisited();
        }

        void Run(string rootdir)
        {
            Node<string> root = new Node<string>(rootdir);
            mVisited.Clear();
            mVisited.Add(rootdir, false);
            this.FillInKids(root);
            this.Iterate(root.GetDepthFirstEnumerator());
            this.ResetVisited();
            this.Iterate(root.GetBreadthFirstEnumerator());
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run(@"C:\Users\valentyne\Desktop\test");
        }
     }
}
