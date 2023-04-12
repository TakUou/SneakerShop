using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
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
    /// Логика взаимодействия для Cash.xaml
    /// </summary>
    public partial class Cash : Page
    {
        BuyerTableAdapter buyer = new BuyerTableAdapter();
        EmployeersTableAdapter employeers= new EmployeersTableAdapter();
        SneakersTableAdapter sneakers= new SneakersTableAdapter();
        ZakazTableAdapter z = new ZakazTableAdapter();
        List<Zakaz> zakaz = new List<Zakaz>();
        int select;
        int select1;
        public Cash()
        {
            InitializeComponent();
            DataGrid.ItemsSource = sneakers.GetData();
            buyercb.ItemsSource= buyer.GetData();
            buyercb.DisplayMemberPath = "name";
            employeecb.ItemsSource= employeers.GetData();
            employeecb.DisplayMemberPath= "name_employee";
            Zakaz.ItemsSource = zakaz;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар, который хотите добавить!");
            }
            else
            {
                Zakaz zak = new Zakaz();
                zak.sneaker = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                zak.cost = (DataGrid.SelectedItem as DataRowView).Row[2].ToString();
                costZakaz.Text = (Convert.ToInt32(costZakaz.Text) + Convert.ToInt32(zak.cost)).ToString();
                zakaz.Add(zak);
                Zakaz.ItemsSource = null;
                Zakaz.ItemsSource = zakaz;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар, который хотите удалить!");
            }
            else
            {
                Zakaz zak = new Zakaz();
                zak = zakaz[select1];
                costZakaz.Text = (Convert.ToInt32(costZakaz.Text) - Convert.ToInt32(zak.cost)).ToString();
                zakaz.RemoveAt(select1);
                Zakaz.ItemsSource = null;
                Zakaz.ItemsSource = zakaz;
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < costZakaz.Text.Length; i++)
            {
                if (!(costZakaz.Text[i] >= '0' && costZakaz.Text[i] <= '9'))
                {
                    MessageBox.Show("Поле не должно содержать символы!");
                    break;
                }
            }
            if (employeecb.Text == "" || buyercb.Text == "" || pay.Text == "" || Zakaz.Items.Count == 0)
            {
                MessageBox.Show("Не все поля заполнены или не выбран ни один товар!");
            }
            else if (Convert.ToInt32(pay.Text) < Convert.ToInt32(costZakaz.Text))
            {
                MessageBox.Show("Недосточно средств!");
            }
            else
            {
                z.InsertQuery(zakaz.Count, Convert.ToInt32(costZakaz.Text));
                string text = "\t\r\n\t  Кассовый чек №" + Convert.ToInt32(z.GetData().Count) + "\n Товары:\n";
                text += "Покупатель:" + buyercb.Text + "\n Работник:" + employeecb.Text;
                foreach(var item in zakaz)
                {
                    var a = item.sneaker; 
                    text += a.ToString() +"\n";
                    var b = item.sneaker + "\n";
                    text += b.ToString();
                }
                text += "Стоимость:" + costZakaz.Text + "\n Внесено:" + pay.Text + "\n Сдача:" + (Convert.ToInt32(costZakaz.Text) -Convert.ToInt32( pay.Text));
                File.WriteAllText("C:\\Users\\user\\Desktop\\чеки.txt",text);
                
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select = DataGrid.SelectedIndex;
        }

        private void Zakaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select= Zakaz.SelectedIndex;
        }
    }
}
