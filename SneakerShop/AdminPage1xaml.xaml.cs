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
using System.Xml.Linq;
using SneakerShop.SneakerShopDataSetTableAdapters;

namespace SneakerShop
{
    /// <summary>
    /// Логика взаимодействия для AdminPage1xaml.xaml
    /// </summary>
    public partial class AdminPage1xaml : Page
    {
        roleTableAdapter role = new roleTableAdapter();
        
        public AdminPage1xaml()
        {
            InitializeComponent();
            DataGrid.ItemsSource = role.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (nameRole.Text == "")
            {
                MessageBox.Show("Поле пусто!");
            }
            else {
                role.InsertQuery(nameRole.Text);
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = role.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedIndex != -1)
            {
                nameRole.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
            else if (DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поле которое хотите удалить!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                role.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = role.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nameRole.Text == "")
            {
                MessageBox.Show("Поле пусто!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                role.UpdateQuery(nameRole.Text, Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = role.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
