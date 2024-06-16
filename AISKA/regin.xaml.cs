using System;
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
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Page
    {
        public MainWindow mainWindow;

        public regin(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0)
{
                if (password.Password.Length > 0) 
	{
                    if (password_Copy.Password.Length > 0) 
		{
                        string[] dataLogin = textBox_login.Text.Split('@'); 
                        if (dataLogin.Length == 2) 
                        {
                            string[] data2Login = dataLogin[1].Split('.'); 
                            if (data2Login.Length == 2)
                            {
                                if (password.Password.Length >= 6)
{
                                    bool en = true; 
                                    bool symbol = false; 
                                    bool number = false; 

                                    for (int i = 0; i < password.Password.Length; i++) 
                                    {
                                        if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false;
                                    if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true; 
                                    if (password.Password[i] == '_' || password.Password[i] == '-' || password.Password[i] == '!') symbol = true; 
                                }

                                if (!en)
                                    MessageBox.Show("Доступна только английская раскладка");
                                else if (!symbol)
                                    MessageBox.Show("Добавьте один из следующих символов: _ - !");
                                else if (!number)
                                    MessageBox.Show("Добавьте хотя бы одну цифру");
                                if (en && symbol && number)
                                {
                                        if (password.Password == password_Copy.Password)
                                        {
                                            MessageBox.Show("Пользователь зарегистрирован");
                                            mainWindow.Select("INSERT INTO [dbo].[users] VALUES ('"+textBox_login.Text+"', '"+password.Password+"')");
                                            mainWindow.OpenPage(MainWindow.pages.login);
                                        }
                                        else MessageBox.Show("Пароли не совпадают");
                                    }
                            }
                            else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                        }
                            else MessageBox.Show("Укажите логин в форме х@x.x");
                        }
                        else MessageBox.Show("Укажите логин в форме х@x.x");

                    }
                    else MessageBox.Show("Повторите пароль");
                }else MessageBox.Show("Укажите пароль");
            }else MessageBox.Show("Укажите логин");
        }
    }
}
