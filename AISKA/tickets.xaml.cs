using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static AISKA.bron;

namespace AISKA
{
    /// <summary>
    /// Логика взаимодействия для tickets.xaml
    /// </summary>
    public partial class tickets : Window
    {
        public tickets()
        {
            InitializeComponent();
            LoadPlanes();
        }

        public class planes
        {
            public string plane { get; set; }
            public string freedate { get; set; }
            public string price { get; set; }
            public string company { get; set; }
        }

        void LoadPlanes()
        {
            DataTable dt_planes = Select("SELECT [plane],[freedate],[price],[company] FROM [dbo].[planes]"); // данные из БД  
            for (int i = 0; i < dt_planes.Rows.Count; i++) // перебираем данные  
            {
                planes dataPlanes = new planes() // создаём экземпляр класса        
                {
                    plane = dt_planes.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_planes.Rows[i][1].ToString(), // указываем логин         
                    price = dt_planes.Rows[i][2].ToString(),
                    company = dt_planes.Rows[i][3].ToString() // казываем пароль     
                };
                listlecs.Items.Add(dataPlanes);
                // выводим строку в список 
            }
        }

        void price()
        {
            listlecs.Items.Clear();
            DataTable dt_planes = Select("SELECT [plane],[freedate],[price],[company] FROM [dbo].[planes] where [price]<='" + maxp.Text + "' and [price] >= '" + minp.Text + "'"); // данные из БД  
            for (int i = 0; i < dt_planes.Rows.Count; i++) // перебираем данные  
            {
                planes dataPlanes = new planes() // создаём экземпляр класса        
                {
                    plane = dt_planes.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_planes.Rows[i][1].ToString(), // указываем логин         
                    price = dt_planes.Rows[i][2].ToString(),
                    company = dt_planes.Rows[i][3].ToString()// казываем пароль     
                };
                listlecs.Items.Add(dataPlanes); // выводим строку в список 
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

        void date()
        {
            listlecs.Items.Clear();
            DataTable dt_planes = Select("SELECT [plane],[freedate],[price],[company] FROM [dbo].[planes] where [freedate]='" + data.Text + "'"); // данные из БД  
            for (int i = 0; i < dt_planes.Rows.Count; i++)
            {
                planes dataPlanes = new planes()
                {
                    plane = dt_planes.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_planes.Rows[i][1].ToString(), // указываем логин         
                    price = dt_planes.Rows[i][2].ToString(),
                    company = dt_planes.Rows[i][3].ToString()
                };
                listlecs.Items.Add(dataPlanes);
            }
        }

        void company()
        {
            listlecs.Items.Clear();
            DataTable dt_planes = Select("SELECT [plane],[freedate],[price],[company] FROM [dbo].[planes] where [company]='" + compania.Text + "'"); // данные из БД  
            for (int i = 0; i < dt_planes.Rows.Count; i++) 
            {
                planes dataPlanes = new planes()       
                {
                    plane = dt_planes.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_planes.Rows[i][1].ToString(), // указываем логин         
                    price = dt_planes.Rows[i][2].ToString(),
                    company = dt_planes.Rows[i][3].ToString()
                };
                listlecs.Items.Add(dataPlanes); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            company();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            date();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            price();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш билет куплен");
        }
    }
}
