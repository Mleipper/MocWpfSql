using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace MocUpWpf.ADORunner
{
    public class MySqlConnector
    {
        private readonly string _connectionString;
                
        public  MySqlConnector(string connstring)
        {
            // return "Server=localhost;Database=ETIC;Uid=root;Pwd=oURtALIaBnoW";
            //"Server=localhost;Database=timelinelogger;Uid=root;Pwd=qL26^N6lp&WU2#a3in#9%qOG$Y^sQ^uO"
            _connectionString = connstring;
            //_queryString = "SELECT * FROM timelinelogger.__efmigrationshistory";            
        }

        /// <summary>
        /// querys a MySQL database and binds the result to a datagrid for presentaion in the view.
        /// </summary>
        /// <param name="queryString">A string representing the query on the dataBase</param>
        /// <param name="dataGrid">The Datagrid From the output view.</param>        
        public void QueryDB(string queryString, DataGrid dataGrid)//TODO Edit this to take an argument
        {
            using var connection =
                    new MySqlConnection(_connectionString);
            // CREATE COMMAND

            var cmd = new MySqlCommand(queryString, connection);
            try
            {
                //create connection
                connection.Open();
                // datareader object creation
                var dataReader = cmd.ExecuteReader();
                //Datatable Creation
                DataTable dt = new DataTable();
                // _dataGrid.SetBinding();// =dataReader
                dt.Load(dataReader);
                //bind DataTable to Datagrid
                dataGrid.ItemsSource = dt.DefaultView;            
                connection.Close();                
            }
            catch (Exception ex)
            {
                //create dataTable to display error message
                DataTable dt = new DataTable();
                dt.Columns.Add("errorMessage");
                DataRow row = dt.NewRow();
                row["errorMessage"] = ex.Message.ToString();
                dt.Rows.Add(row);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }       
    }
}
