using System;
using System.Collections.Generic;
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
            command.CommandText = "SELECT firstName, middleName, lastName FROM " + databaseName + "." + tableName + " WHERE matNumber=\"" + matNumber + "\"";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader["firstName"].ToString() + " " + reader["middleName"].ToString() + " " + reader["lastName"].ToString();
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

        public void SaveTableToExcel(string fileName, string connectionString, string databaseName, string tableName)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + databaseName + "." + tableName, connection);
                DataSet dataSet = new DataSet();

                connection.Open();
                adapter.Fill(dataSet, "students");
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
