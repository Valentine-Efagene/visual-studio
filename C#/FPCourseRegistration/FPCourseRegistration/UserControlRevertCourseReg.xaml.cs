using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControlRevertCourseReg.xaml
    /// </summary>
    public partial class UserControlRevertCourseReg : UserControl
    {
        LoginData data = null;
        SerialPort serial = new SerialPort();
        BackgroundWorker fingerPrint;
        bool fingerVerified = false;
        int id = 0;
        public string matNumber;

        public UserControlRevertCourseReg(LoginData data)
        {
            InitializeComponent();
            this.data = data;

            fingerPrint = new BackgroundWorker();
            fingerPrint.WorkerSupportsCancellation = true;
            fingerPrint.DoWork += new DoWorkEventHandler(fingerPrint_DoWork);
            fingerPrint.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fingerPrint_RunWorkerCompleted);
        }

        private void fingerPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fingerVerified == true)
            {
                CheckBoxVerified.IsChecked = true;
            }
        }

        private void fingerPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            string rec;

            try
            {
                serial.Open();

                do
                {
                    rec = serial.ReadLine();
                } while (rec.Length < 1);

                if (rec.Length > 0)
                {
                    string pattern = @"\#\d";
                    Regex rgx = new Regex(pattern);
                    MatchCollection mc = rgx.Matches(rec);
                    id = Convert.ToInt32(mc[0].ToString().Replace("#", ""));
                }

                if (id != 0)
                {
                    MySqlHelper helper = new MySqlHelper();
                    string connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();
                    fingerVerified = helper.IDConfirmed(connectionString, "db_course_registration", "t_students", matNumber, id);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                serial.Close();
                fingerPrint.CancelAsync();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxVerified.IsChecked == false)
            {
                MessageBox.Show("Please verify your finger print");
                return;
            }

            MySqlHelper helper = new MySqlHelper();

            try
            {
                string connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();
                fingerVerified = helper.IDConfirmed(connectionString, "db_course_registration", "t_students", TextBoxMatNumber.Text.ToUpper(), id);

                if (fingerVerified == true)
                {
                    helper.RevertRegistration(connectionString, "db_course_registration", "t_courses", TextBoxMatNumber.Text);
                }
                else
                {
                    MessageBox.Show("Finger print could not be verified.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
            finally
            {
                fingerVerified = false;
                id = 0;
                CheckBoxVerified.IsChecked = false;
            }
        }

        private void ButtonFingerprint_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ComboBoxPort.Text == "PORT")
            {
                MessageBox.Show("Choose a port!");
                return;
            }

            serial.PortName = ComboBoxPort.Text;
            serial.BaudRate = Convert.ToInt32("9600");
            serial.Handshake = System.IO.Ports.Handshake.None;
            serial.Parity = Parity.None;
            serial.DataBits = 8;
            serial.StopBits = StopBits.One;

            matNumber = TextBoxMatNumber.Text;
            fingerPrint.RunWorkerAsync();
        }

        private void ButtonFingerprint_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            fingerPrint.CancelAsync();
        }
    }
}
