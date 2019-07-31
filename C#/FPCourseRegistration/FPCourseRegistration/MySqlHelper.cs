using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace FPCourseRegistration
{
    class MySqlHelper
    {
        public void LoadTable(DataGrid dataGrid, string connectionString, string databaseName, string tableName)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + databaseName + "." + tableName, connection);
                DataSet dataSet = new DataSet();

                connection.Open();
                adapter.Fill(dataSet, "students");
                dataGrid.ItemsSource = dataSet.Tables["students"].DefaultView;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetStudentName(string connectionString, string databaseName, string tableName, string matNumber)
        {
            string result = null;
            matNumber = matNumber.ToUpper().Trim();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT f_first_name, f_middle_name, f_last_name FROM " +
                databaseName + "." + tableName + " WHERE f_mat_number=\"" + matNumber + "\"";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader["f_first_name"].ToString() + " " + reader["f_middle_name"].ToString() +
                        " " + reader["f_last_name"].ToString();
                }

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void RegisterStudents(string connectionString, string databaseName, string tableName, 
            string matNumber, string firstName, string middleName, string lastName, string s_level, string s_id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            int level = 0, id = 0;

            try
            {
                level = Convert.ToInt32(s_level);
                id = Convert.ToInt32(s_id);
            }
            catch
            {
                MessageBox.Show("Value not acceptable.");
                return;
            }

            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO " + databaseName + "." + tableName +
                    " (f_mat_number, f_first_name, f_middle_name, f_last_name, f_level, f_fingerprint_id) VALUES(" + "\"" + matNumber.ToUpper() + "\"" + ", " + 
                    "\"" + firstName.ToUpper() + "\"" + ", " + "\"" + middleName.ToUpper() + "\"" + ", " + "\"" + 
                    lastName.ToUpper() + "\"" + ", " + level + ", " + id + " )";

                int ret = command.ExecuteNonQuery();
                MessageBox.Show(Convert.ToString("DONE"));

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + command.CommandText);
            }
        }

        public void RevertRegistration(string connectionString, string databaseName, string tableName,
            string matNumber)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "DELETE * FROM " + databaseName + "." + tableName + " WHERE f_mat_number=\"" + matNumber.ToUpper().Trim() + "\"";

                int ret = command.ExecuteNonQuery();
                MessageBox.Show(Convert.ToString("DONE"));

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + command.CommandText);
            }
        }

        public void TestConnection(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                connection.Close();
                MessageBox.Show("Account Verified");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RegisterCourses(string connectionString, string databaseName, string tableName, string matNumber, ObservableCollection<Course> courses)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            try
            {
                connection.Open();
                foreach( Course course in courses)
                {
                    command.CommandText = "INSERT INTO " + databaseName + "." + tableName +
                        " (f_code, f_credit, f_mat_number) VALUES(" + "\"" + course.Code.ToUpper() + "\"" + ", " + course.Credit + ", " +
                        "\"" + matNumber.ToUpper() + "\"" + ")";
                    int ret = command.ExecuteNonQuery();
                    MessageBox.Show(Convert.ToString("DONE"));
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + command.CommandText);
            }
        }

        public bool IDConfirmed(string connectionString, string databaseName, string tableName, string matNumber, int id)
        {
            string matNum = null;
            matNumber = matNumber.ToUpper().Trim();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT f_mat_number FROM " +
                databaseName + "." + tableName + " WHERE f_fingerprint_id = " + id;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    matNum = reader["f_mat_number"].ToString();
                }

                connection.Close();

                return matNum == matNumber ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + command.CommandText);
                return false;
            }
        }

        public void SaveTableToExcel(string fileName, string connectionString, string databaseName, string tableName)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + databaseName + "." + tableName, connection);
                DataSet dataSet = new DataSet();

                connection.Open();
                adapter.Fill(dataSet, "t_students");
                connection.Close();

                ExportDataSetToExcel(dataSet, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExportDataSetToExcel(DataSet ds, string fileName)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();

            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }

                excelWorkSheet.SaveAs(table.TableName);
            }

            excelWorkBook.SaveAs(fileName);
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
