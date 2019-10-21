using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Organiser
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        string directory = null;
        IDictionary<string, string> types_folders = new Dictionary<string, string>
            {
                { "video", "Videos" },
                { "music", "Music" },
                { "document", "Documents" },
                { "compressed", "Compressed" },
                { "picture", "Pictures" },
                { "program", "Programs" }
            };

        public Organiser(string directory)
        {
            this.directory = directory;
        }

        public void CreateFolders(IDictionary<string, string> types_folders)
        {
            foreach (KeyValuePair<string, string> item in types_folders)
            {
                string newDir = directory + "\\" + item.Value;

                if (!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                }
            }
        }

        public void Organise()
        {
            CreateFolders(types_folders);

            foreach (KeyValuePair<string, string> item in types_folders)
            {
                foreach (string file in GetFilesOfType(item.Key))
                {
                    File.Move(file, directory + "\\" + item.Value + "\\" + Path.GetFileName(file));
                }
            }
        }

        public IEnumerable<string> GetFilesOfType(string type)
        {
            IEnumerable<string> files = null;
            IDictionary<string, string> extensions = new Dictionary<string, string>
            {
                { "video", "mkv|mp4|avi" },
                { "music", "wav|mp3" },
                { "document", "pdf|doc|docx|txt|py|cpp|m|c|ipynb|xlsx|csv" },
                { "compressed", "zip|rar" },
                { "picture", "gif|png|jpg|ico" },
                { "program", "out|exe" }
            };

            if (type == "others")
            {
                files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + "sys" + ")$"));
                return files;
            }

            files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + extensions[type.ToLower()] + ")$"));
            return files;
        }

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
    }
}
