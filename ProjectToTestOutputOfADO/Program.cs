using System;
using MocUpWpf.ADORunner;

namespace ProjectToTestOutputOfADO
{
    class Program
    {
        static void Main(string[] args)
        {

            var sql = new MySqlConnector("Server=localhost;Database=timelinelogger;Uid=root;Pwd=qL26^N6lp&WU2#a3in#9%qOG$Y^sQ^uO");
            Console.WriteLine("Please enter Your MySql statement");
            var queryString = Console.ReadLine();
            
            sql.QueryDB(queryString);
            Console.ReadKey();
        }
    }
}
