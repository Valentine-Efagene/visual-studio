﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mac_Finder
{
    public partial class Form1 : Form
    {


        public Form1()
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
            rtcResult.Text = "";

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
                            rtcResult.Text = tbMAC.Text.Trim() + " was found in " + "\n\n";
                        }

                        rtcResult.AppendText(count + ". " + Path.GetFileName(s) + "\n");
                    }
                }
            }
            
            if( count == 0)
            {
                rtcResult.Text = tbMAC.Text + " was not found.";
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
            string fileName = tbFolder.Text;
            rtcResult.Text = "";

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
                        }
                    }
                }
            }
        }
    }
}
