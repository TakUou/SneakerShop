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
    /// Логика взаимодействия для Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }


        private void Firm_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Firm();
        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Country();
        }

        private void Provider_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Provider();
        }

        private void StockSneakers_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new StockSneakers();
        }
    }
}
