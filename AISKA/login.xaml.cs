﻿using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {

        public MainWindow mainWindow;

        public login(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow= _mainWindow;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0) 
            {
                if (password.Password.Length > 0)       
                {                  
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + textBox_login.Text + "' AND [password] = '" + password.Password + "'");
                    if (dt_user.Rows.Count > 0)       
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        mainWindow.OpenPage(MainWindow.pages.acceptbase);
                    }
                    else MessageBox.Show("Пользователя не найден");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }
    }
}
