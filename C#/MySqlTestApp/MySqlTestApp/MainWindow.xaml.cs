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

namespace MySqlTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlHelper db = new MySqlHelper();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void studentTable_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = "datasource=localhost; port=3306; username=valentyne; password=#Valentyne101";
            string databaseName = "students";
            string tableName = "students";
            string fileName = "C:\\Users\\valentyne\\Documents\\spreedsheets\\test.xlsx";
            //db.LoadTable(studentTable, connectionString, databaseName, tableName);
            db.SaveTableToExcel(fileName, connectionString, databaseName, tableName);
        }
    }
}
