﻿using System;
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
    public partial class UserControlRegister : UserControl
    {
        LoginData data = null;

        public UserControlRegister(LoginData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void ButtonFindStudent_Click(object sender, RoutedEventArgs e)
        {
            //SELECT `firstName`,`middleName`,`lastName` FROM `students` WHERE matNumber = "ENG1403447"
            string connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();

        }
    }
}
