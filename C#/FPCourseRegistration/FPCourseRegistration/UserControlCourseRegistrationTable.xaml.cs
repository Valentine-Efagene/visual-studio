using Microsoft.Win32;
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
    /// Interaction logic for UserControlCourseRegistrationTable.xaml
    /// </summary>
    public partial class UserControlCourseRegistrationTable : UserControl
    {
        MySqlHelper db = new MySqlHelper();
        LoginData data;
        string connectionString;
        string databaseName;
        string tableName;

        public UserControlCourseRegistrationTable(LoginData data)
        {
            InitializeComponent();
            this.data = data;
            connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();
            databaseName = "db_course_registration";
            tableName = "t_courses";
            db.LoadTable(DataGridCourses, connectionString, databaseName, tableName);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.Filter = "Excel Spreadsheet (*.xlsx) | *.xlsx";

            if (sfd.ShowDialog() == true)
            {
                db.SaveTableToExcel(sfd.FileName, connectionString, databaseName, tableName);
            }
        }
    }
}
