﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

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
                
                ExportDataSetToExcel(dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportDataSetToExcel(DataSet ds)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"C:\Org.xlsx");

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
            }

            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();

        }

    }
}
