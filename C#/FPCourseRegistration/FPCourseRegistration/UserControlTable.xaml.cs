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
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class UserControlTable : UserControl
    {
        MySqlHelper db = new MySqlHelper();

        public UserControlTable(LoginData data)
        {
            InitializeComponent();
            string connectionString = "datasource=localhost; port=3306; username=" + data.getUsername() + "; password=" + data.getPassword();
            string databaseName = "students";
            string tableName = "students";
            string fileName = "C:\\Users\\valentyne\\Documents\\spreedsheets\\test.xlsx";
            db.LoadTable(DataGridStudents, connectionString, databaseName, tableName);
            //db.SaveTableToExcel(fileName, connectionString, databaseName, tableName);
        }
    }
}
