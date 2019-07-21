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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        string userName;
        string password;
        LoginData data = null;

        public UserControlLogin(LoginData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.setUserName(TextBoxUserName.Text);
            data.setPassword(PasswordBoxPassword.Password);
        }
    }
}
