using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace MocUpWpf.ADORunner
{
    public class MySqlConnector
    {
        private readonly string _connectionString;
        private string _queryString;
        
        public  MySqlConnector(string connstring)
        {
            //"Server=localhost;Database=timelinelogger;Uid=root;Pwd=qL26^N6lp&WU2#a3in#9%qOG$Y^sQ^uO"
            _connectionString = connstring;
            _queryString = "SELECT * FROM timelinelogger.__efmigrationshistory";
            
        }




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
                // datareader object
                var dataReader = cmd.ExecuteReader();
                
               // _dataGrid.SetBinding();// =dataReader

                var fieldcount = dataReader.FieldCount;
                //var rows = dataReader.
                for (int i = 0; i < fieldcount; i++)
                {
                    dataGrid.Columns.Add();
                }
                var dataGridCol = new DataGridColumn("ff");
                // how it works for console application 
                for (int i = 0; i < fieldcount; i++)
                {
                    var name = dataReader.GetName(i);
                    
                    dataGrid.Columns.Add(name);// not how to do this
                    Console.Write(name+ " | ");
                }
                dataGrid.Columns.Add(name);// not how to do this
                Console.WriteLine();
                
                //only reads out first coloum
                for (int i = 0; i < fieldcount; i++)
                {
                    while (dataReader.Read())
                    {
                        for (int x = 0; x < fieldcount; x++)
                        {
                            Console.Write("| "+dataReader[x].ToString()+" |");
                        }
                        Console.WriteLine();
                    }
                    
                }
                  

                

                foreach (var item in dataReader)
                {
                    Console.WriteLine(item.ToString());
                }
                connection.Close();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
       
    }
}
