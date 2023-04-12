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
    /// Логика взаимодействия для Salesman.xaml
    /// </summary>
    public partial class Salesman : Window
    {
        public Salesman()
        {
            InitializeComponent();
        }

        private void Buyer_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Buyer();
        }

        private void CashRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Cash();
        }
    }
}
