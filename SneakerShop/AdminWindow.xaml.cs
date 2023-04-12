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
using System.Windows.Shapes;

namespace SneakerShop
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void Role_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AdminPage1xaml();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AdminPage2();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AdminPage3();
        }
    }
}
