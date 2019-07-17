using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlTestApp
{
    class MySqlHelper
    {
        public void LoadTable( DataGridView dataGrid )
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; username=valentyne; password=#Valentyne101");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM students.students", connection);
                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "students");
                dataGrid.DataSource = dataSet.Tables["students"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
