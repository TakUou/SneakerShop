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
    /// Логика взаимодействия для Department.xaml
    /// </summary>
    public partial class Department : Page
    {
        DepartmentTableAdapter department = new DepartmentTableAdapter();
        public Department()
        {
            InitializeComponent();
            DataGrid.ItemsSource = department.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
            }
            else
            {
                department.InsertQuery(name.Text);
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = department.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("Поле не заполнено!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                department.UpdateQuery(name.Text,Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = department.GetData();
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
                department.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = department.GetData();
                DataGrid.SelectedIndex = -1;
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid.SelectedIndex != -1) 
            {
                name.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
            }
            else if (DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }

        }
    }
}
