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
    /// Логика взаимодействия для Ceo.xaml
    /// </summary>
    public partial class Ceo : Window
    {
        public Ceo()
        {
            InitializeComponent();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Buys();
        }

        private void Department_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Department();
        }
    }
}
