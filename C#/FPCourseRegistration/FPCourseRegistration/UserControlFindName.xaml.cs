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
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UserControlFindName : UserControl
    {
        LoginData data = null;

        public UserControlFindName(LoginData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void ButtonFindStudent_Click(object sender, RoutedEventArgs e)
        {
            MySqlHelper helper = new MySqlHelper();
            string connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();
            TextBoxName.Text = helper.GetStudentName(connectionString, "students", "students", TextBoxMatNumber.Text);
            TextBoxName.IsEnabled = true;
        }
    }
}
