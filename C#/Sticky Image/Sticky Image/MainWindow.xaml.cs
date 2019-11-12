using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sticky_Image
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"current.txt";

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(path))
            {
                string savedImage = File.ReadAllText(path);

                if(savedImage != "")
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(savedImage);
                    b.EndInit();

                    image.Source = b;
                }
            }

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(openFileDialog.FileName);
                    System.IO.File.WriteAllText(path, openFileDialog.FileName);
                    b.EndInit();

                    // ... Get Image reference from sender.
                    var image = sender as Image;
                    // ... Assign Source.
                    image.Source = b;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2)
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                System.IO.File.WriteAllText(path, files[0]);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(files[0]);
                b.EndInit();

                // ... Get Image reference from sender.
                var image = sender as Image;
                // ... Assign Source.
                image.Source = b;
            }
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
                e.Effects = DragDropEffects.None;
        }
    }
}
