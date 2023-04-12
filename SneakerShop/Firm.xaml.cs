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
    /// Логика взаимодействия для Firm.xaml
    /// </summary>
    public partial class Firm : Page
    {
        FirmTableAdapter firm = new FirmTableAdapter();
        public Firm()
        {
            InitializeComponent();
            DataGrid.ItemsSource = firm.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (nameFirm.Text == "")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                firm.InsertQuery(nameFirm.Text);
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = firm.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (nameFirm.Text == "")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                firm.UpdateQuery(nameFirm.Text, Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = firm.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поле для удаления!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                firm.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = firm.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedIndex != -1)
            {
                nameFirm.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
            if (DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
