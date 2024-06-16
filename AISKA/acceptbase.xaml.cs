using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для acceptbase.xaml
    /// </summary>
    public partial class acceptbase : Page
    {

        public MainWindow mainWindow;

        public acceptbase(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GPS win2 = new GPS();
            win2.Show();
            this.Visibility=Visibility.Hidden;
            Application.Current.MainWindow.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bron win3=new bron();
            win3.Show();
            this.Visibility=Visibility.Hidden;
            Application.Current.MainWindow.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tickets win4=new tickets();
            win4.Show();
            this.Visibility=Visibility.Hidden;  
            Application.Current.MainWindow.Close();
        }
    }
}
