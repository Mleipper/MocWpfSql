using MocUpWpf.ADORunner;
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

namespace MocUpWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //onClick sets value of sqlQuery to that of the entered text
            var sqlQuery = TxtInputQuery.Text;
            if (sqlQuery != null && sqlQuery!="")
            {
                //"Server=localhost;Database=timelinelogger;Uid=root;Pwd=qL26^N6lp&WU2#a3in#9%qOG$Y^sQ^uO"
                //"Server=localhost;Database=ETIC;Uid=root;Pwd=oURtALIaBnoW"
                var sqlData = new MySqlConnector("Server=localhost;Database=ETIC;Uid=root;Pwd=oURtALIaBnoW");
                sqlData.QueryDB(sqlQuery,QueryResult);     
            }

            //QueryResult =; // can reference Datagrid here 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
