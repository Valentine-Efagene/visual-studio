using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Mac_Finder
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void chooseFolder(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fileChooser = new FolderBrowserDialog())
            {
                fileChooser.RootFolder = Environment.SpecialFolder.Desktop;

                if ( fileChooser.ShowDialog() == DialogResult.OK )
                {
                    tbFolder.Text = fileChooser.SelectedPath;
                }
            }
        }

        private void findMac(object sender, EventArgs e)
        {
            int count = 0;
            string fileName = tbFolder.Text;
            rtbResult.Text = "";

            if (Directory.Exists(fileName))
            {
                string[] fileList = Directory.GetFiles(tbFolder.Text);

                foreach (string s in fileList)
                {
                    string fileContent = File.ReadAllText(s);

                    if (fileContent.Contains(tbMAC.Text.Trim().ToLower()))
                    {
                        count++;

                        if(count == 1)
                        {
                            rtbResult.Text = tbMAC.Text.Trim() + " was found in " + "\n\n";
                        }

                        rtbResult.AppendText(count + ". " + Path.GetFileName(s) + "\n");
                    }
                }
            }
            
            if( count == 0)
            {
                rtbResult.Text = tbMAC.Text + " was not found.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About App:\nThis app simply searches for a string in all the files in a folder.\n" +
                "The original intent was to use it to search for MAC addresses in a folder containing several\n" +
                "MAC access control lists. However, its scope is not limited to MAC addresses." +
                "\n\n" +
                "About Developer:\n" +
                "Name: Valentine Edesiri Efagene\n" +
                "Whatsapp number: 07053229765\n" +
                "Mobile number: 09034360573\n" +
                "Nationality: Nigerian");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string MAC = tbMAC.Text.Trim();
            rtbResult.Text = "";
            string pattern = "[a-fA-F0-9]{4}.[a-fA-F0-9]{4}.[a-fA-F0-9]{4}";
            Regex rgx = new Regex(pattern);

            if (!rgx.IsMatch(MAC))
            {
                rtbResult.AppendText(MAC + " is not a valid MAC address!");
                return;
            }

            string fileName = tbFolder.Text;
            int count = 0;

            if (Directory.Exists(fileName))
            {
                string[] fileList = Directory.GetFiles(tbFolder.Text);

                foreach (string s in fileList)
                {
                    string[] lines = File.ReadAllLines(s);

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(s))
                    {
                        foreach(string line in lines)
                        {
                            if(!line.Contains(tbMAC.Text.Trim().ToLower()))
                            {
                                file.WriteLine(line);
                            }
                            else
                            {
                                count++;
                                rtbResult.Text = tbMAC.Text.Trim() + " was removed from " + Path.GetFileName(s) + "\n\n";
                            }
                        }
                    }
                }
            }

            if(count == 0)
            {
                rtbResult.AppendText( tbMAC.Text.Trim() + " was not found.");
            }
        }

        private void tbFolder_dragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[ 0 ];

                if (Directory.Exists(path))
                {
                    tbFolder.Text = path;
                }
            }
        }

        private void tbFolder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
