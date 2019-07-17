using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
