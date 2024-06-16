using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace AISKA
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPage(pages.login);
        }

        public enum pages
        {
            login,
            regin,
            acceptbase,

        }

        public void OpenPage(pages pages)
        {
            if(pages == pages.login)
            {
                frame.Navigate(new login(this));
            }else if (pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }else if (pages== pages.acceptbase)
            {
                frame.Navigate(new acceptbase(this));
            }
        }

        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");                
                                                                           
            SqlConnection sqlConnection = new SqlConnection("server=KOMPUTER;Trusted_Connection=Yes;DataBase=AIS;");
            sqlConnection.Open();                                           
            SqlCommand sqlCommand = sqlConnection.CreateCommand();         
            sqlCommand.CommandText = selectSQL;                             
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);                                 
            return dataTable;
        }

        

    }
}
