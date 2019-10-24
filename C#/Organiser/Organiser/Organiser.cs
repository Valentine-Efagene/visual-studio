using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Organiser
{
    public class Organiser
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string directory = null;
        readonly IDictionary<string, string> types_folders = new Dictionary<string, string>
            {
                { "video", "Videos" },
                { "music", "Music" },
                { "document", "Documents" },
                { "compressed", "Compressed" },
                { "picture", "Pictures" },
                { "program", "Programs" }
            };

        public Organiser()
        {
            this.directory = GetActiveWindowPath();
        }

        public void Organise()
        {
            foreach (KeyValuePair<string, string> item in types_folders)
            {
                foreach (string file in GetFilesOfType(item.Key))
                {
                    try
                    {
                        File.Move(file, directory + "\\" + item.Value + "\\" + Path.GetFileName(file));
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Directory.CreateDirectory(directory + "\\" + item.Value);
                        File.Move(file, directory + "\\" + item.Value + "\\" + Path.GetFileName(file));
                    }
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
                { "document", "pdf|doc|docx|txt|py|cpp|m|c|ipynb|xlsx|csv|ppt|pptx|accdb|py|cpp|c|html|js|css|m" },
                { "compressed", "zip|rar" },
                { "picture", "gif|png|jpg|ico" },
                { "program", "out|exe|bat" }
            };

            if (type == "others")
            {
                files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + "sys" + ")$"));
                return files;
            }

            files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @".+\.(" + extensions[type.ToLower()] + ")$"));
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
