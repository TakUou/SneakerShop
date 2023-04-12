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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SneakerShop.SneakerShopDataSetTableAdapters;

namespace SneakerShop
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginTableAdapter login = new LoginTableAdapter(); 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = login.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == Login.Text && allLogins[i][2].ToString() == Password.Password)
                {
                    if (Login.Text == "admin")
                    {
                        AdminWindow window = new AdminWindow();
                        window.Show();
                        this.Close();
                    }
                    if (Login.Text == "salesman") 
                    {
                        Salesman register= new Salesman();
                        register.Show();
                        this.Close();
                    }
                    if (Login.Text == "storekeeper")
                    {
                        Stock stock = new Stock(); 
                        stock.Show();
                        this.Close();
                    }
                    if(Login.Text == "ceo")
                    {
                        Ceo ceo = new Ceo();
                        ceo.Show();
                        this.Close();
                    }
                }
                else Error.Text = "Неверный логин или пароль";
            }

        }
    }
}
