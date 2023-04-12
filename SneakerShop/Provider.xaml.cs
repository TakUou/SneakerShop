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
using SneakerShop.SneakerShopDataSetTableAdapters;

namespace SneakerShop
{
    /// <summary>
    /// Логика взаимодействия для Provider.xaml
    /// </summary>
    public partial class Provider : Page
    {
        ProviderTableAdapter provider = new ProviderTableAdapter();
        public Provider()
        {
            InitializeComponent();
            DataGrid.ItemsSource = provider.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(nameProvider.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
            }
            else
            {
                provider.InsertQuery(nameProvider.Text);
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = provider.GetData();
                DataGrid.SelectedIndex = -1;
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nameProvider.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                provider.UpdateQuery(nameProvider.Text, Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = provider.GetData();
                DataGrid.SelectedIndex = -1;
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Поле для удаления не выбрано!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                provider.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = provider.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid.SelectedIndex != -1) 
            {
                nameProvider.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
            if (DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
