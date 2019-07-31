using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPCourseRegistration
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginData data;

        public MainWindow()
        {
            InitializeComponent();

            data = new LoginData();
            UserControl usc = new UserControlLogin(data);
            GridMain.Children.Add(usc);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemTable":
                    usc = new UserControlTable(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemFindName":
                    usc = new UserControlFindName(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemRegister":
                    usc = new UserControlRegisterCourses(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemRegisterStudents":
                    usc = new UserControlRegisterStudents(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemRegisterCourseRegistrationTable":
                    usc = new UserControlCourseRegistrationTable(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemRevertCourseReg":
                    usc = new UserControlRevertCourseReg(data);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemBackup":
                    Backup();
                    break;
                case "ItemRestore":
                    Restore();
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonData_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new UserControlLogin(data);
            GridMain.Children.Add(usc);
        }

        void Backup()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.Filter = "MySQL file (*.sql) | *.sql";

            if (sfd.ShowDialog() == true)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " +
                        "mysqldump -u " + data.getUsername() + " -p" + data.getPassword() + " db_course_registration > " + sfd.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        void Restore()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.Filter = "MySQL file (*.sql) | *.sql";

            if (sfd.ShowDialog() == true)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " +
                        "mysqldump -u " + data.getUsername() + " -p" + data.getPassword() + " db_course_registration < " + sfd.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the software part of a course registration " +
                "project that uses an arduino fingerprint sensor, such as the R307 from adafruit, " +
                "using Ladyada's fingerprint library.");
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Call: 09034360573");
        }
    }
}
