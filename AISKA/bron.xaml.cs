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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AISKA
{
    /// <summary>
    /// Логика взаимодействия для bron.xaml
    /// </summary>
    public partial class bron : Window
    {
        public bron()
        {
            InitializeComponent();
            LoadHotels();
        }

        public class hotels
        {
            public string hotel { get; set; }
            public string freedate { get; set; }
            public string price { get; set; }
        }

        void LoadHotels()
        {
            DataTable dt_hotels = Select("SELECT [hotel],[freedate],[price] FROM [dbo].[hotels]"); // данные из БД  
            for (int i = 0; i < dt_hotels.Rows.Count; i++) // перебираем данные  
            {
                hotels dataHotels = new hotels() // создаём экземпляр класса        
                {
                    hotel = dt_hotels.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_hotels.Rows[i][1].ToString(), // указываем логин         
                    price = dt_hotels.Rows[i][2].ToString() // казываем пароль     
                };
                listlecs.Items.Add(dataHotels);
                // выводим строку в список 
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
        void price()
        {
            listlecs.Items.Clear();
            DataTable dt_hotels = Select("SELECT [hotel],[freedate],[price] FROM [dbo].[hotels] where [price]<='" + maxp.Text + "' and [price] >= '" + minp.Text + "'"); // данные из БД  
            for (int i = 0; i < dt_hotels.Rows.Count; i++) // перебираем данные  
            {
                hotels dataHotels = new hotels() // создаём экземпляр класса        
                {
                    hotel = dt_hotels.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_hotels.Rows[i][1].ToString(), // указываем логин         
                    price = dt_hotels.Rows[i][2].ToString() // казываем пароль     
                };
                listlecs.Items.Add(dataHotels); // выводим строку в список 
            }
        }

        void date()
        {
            listlecs.Items.Clear();
            DataTable dt_hotels = Select("SELECT [hotel],[freedate],[price] FROM [dbo].[hotels] where [freedate]='" + data.Text + "'"); // данные из БД  
            for (int i = 0; i < dt_hotels.Rows.Count; i++) // перебираем данные  
            {
                hotels dataHotels = new hotels() // создаём экземпляр класса        
                {
                    hotel = dt_hotels.Rows[i][0].ToString(), // указываем изображение из таблицы    
                    freedate = dt_hotels.Rows[i][1].ToString(), // указываем логин         
                    price = dt_hotels.Rows[i][2].ToString() // казываем пароль     
                };
                listlecs.Items.Add(dataHotels); // выводим строку в список 
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        price();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
date();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваш отель забронирован");
        }
    }
}
