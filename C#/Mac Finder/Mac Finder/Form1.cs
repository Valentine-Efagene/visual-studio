using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            } // end using
        }

        private void findMac(object sender, EventArgs e)
        {

        }
    }
}
