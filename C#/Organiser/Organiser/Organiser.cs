using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Linq;
using Tree;

namespace Organiser
{
    public class Organiser
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string directory = null;

        Node<string> program = new Node<string>("Programs");
        Node<string> sound = new Node<string>("Sounds");
        Node<string> video = new Node<string>("Videos");
        Node<string> picture = new Node<string>("Pictures");
        Node<string> compressed = new Node<string>("Compressed");
        Node<string> document = new Node<string>("Documents");

        Node<string> book = new Node<string>("Books");
        Node<string> pdf = new Node<string>("pdf");
        Node<string> epub = new Node<string>("epub");

        Node<string> code = new Node<string>("Codes");
        Node<string> java = new Node<string>("Java");
        Node<string> matlab = new Node<string>("Matlab");
        Node<string> cpp = new Node<string>("Cpp");
        Node<string> c = new Node<string>("C");
        Node<string> python = new Node<string>("Python");
        Node<string> arduino = new Node<string>("Arduino");

        Node<string> graphics = new Node<string>("Graphics");
        Node<string> corel = new Node<string>("Corel");
        Node<string> photoshop = new Node<string>("Photoshop");
        Node<string> word = new Node<string>("Word");
        Node<string> spreadsheet = new Node<string>("Spreadsheets");
        Node<string> illustrator = new Node<string>("Illustrator");
        Node<string> font = new Node<string>("Fonts");
        Node<string> presentation = new Node<string>("Presentations");
        Node<string> database = new Node<string>("Databases");
        Node<string> text = new Node<string>("Text");

        IDictionary<Node<string>, string> extensions = null;

        public Organiser()
        {
            //this.directory = GetActiveWindowPath();
            this.directory = @"C:\Users\valentyne\Desktop\test2";

            extensions = new Dictionary<Node<string>, string>
            {
                {text, "txt"},
                {word, "docx|doc"},
                {spreadsheet, "xlxs|csv"},
                {presentation, "ppt|pptx"},
                {corel, "cdr"},
                {cpp, "cpp"},
                {python, "py"},
                {java, "java"},
                {arduino, "ino"},
                {video, "avi|mp4|mkv"},
                {picture, "gif|png|jpg|ico|JPG|PNG|jpeg|JPEG"},
                {compressed, "zip|rar"},
                {sound, "wav|mp3"},
                {program, "out|exe|bat|msi" }
            };

            document.Children.Add(book);

            book.Children.Add(epub);
            book.Children.Add(pdf);

            document.Children.Add(code);
            code.Children.Add(arduino);
            code.Children.Add(c);
            code.Children.Add(cpp);
            code.Children.Add(java);
            code.Children.Add(matlab);
            code.Children.Add(python);

            document.Children.Add(graphics);
            graphics.Children.Add(corel);
            graphics.Children.Add(photoshop);
            graphics.Children.Add(illustrator);

            document.Children.Add(word);
            document.Children.Add(spreadsheet);
            document.Children.Add(font);
            document.Children.Add(database);
            document.Children.Add(text);
            document.Children.Add(presentation);
        }

        public void Organise()
        {
            foreach (KeyValuePair<Node<string>, string> item in extensions)
            {
                foreach (string file in GetFilesOfType(item.Value))
                {
                    try
                    {
                        File.Move(file, computePath(item.Key) + "\\" + Path.GetFileName(file));
                    }
                    catch (DirectoryNotFoundException)
                    {
                        CreateDirectory(item.Key);
                        File.Move(file, computePath(item.Key) + "\\" + Path.GetFileName(file));
                    }
                }
            }
        }

        public string computePath(Node<string> category)
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

        public void CreateDirectory(Node<string> category)
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
            
            string p = directory;

            for (int i = 0; i < path.Length; i++)
            {
                p += "\\" + path[i];

                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
            }
        }

        public IEnumerable<string> GetFilesOfType(string type)
        {
            IEnumerable<string> files = null;

            files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + type + ")$"));
            return files;
        }

        public string GetDirectory()
        {
            return directory;
        }

        public string GetActiveWindowPath()
        {
            IntPtr handle = GetForegroundWindow();
            // Add reference 'Microsoft Internet Controls' to use SHDocVw
            var explorer = new SHDocVw.ShellWindows().Cast<SHDocVw.InternetExplorer>().Where(hwnd => hwnd.HWND == (int)handle).FirstOrDefault();

            if (explorer != null)
            {
                string path = new Uri(explorer.LocationURL).LocalPath;
                return path;
            }

            return null;
        }
    }
}
