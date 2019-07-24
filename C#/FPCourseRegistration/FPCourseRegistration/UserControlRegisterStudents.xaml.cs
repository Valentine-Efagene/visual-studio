using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlRegisterStudents.xaml
    /// </summary>
    public partial class UserControlRegisterStudents : UserControl
    {
        LoginData data = null;

        public UserControlRegisterStudents(LoginData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            MySqlHelper helper = new MySqlHelper();

            try
            {
                string connectionString = "datasource=localhost; port=3306; username=" +
                    data.getUsername() + "; password=" + data.getPassword();

                helper.RegisterStudents(connectionString, "db_course_registration", "t_students", 
                    TextBoxMatNumber.Text.ToUpper(), TextBoxFirstName.Text.ToUpper(),
                    TextBoxMiddleName.Text.ToUpper(), TextBoxLastName.Text.ToUpper(),
                    TextBoxLevel.Text.ToUpper());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
        }
    }
}
