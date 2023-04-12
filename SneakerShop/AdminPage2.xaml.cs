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
    /// Логика взаимодействия для AdminPage2.xaml
    /// </summary>
    public partial class AdminPage2 : Page
    {
        EmployeersTableAdapter employeers = new EmployeersTableAdapter();
        LoginTableAdapter logins = new LoginTableAdapter();
        public AdminPage2()
        {
            InitializeComponent();
            DataGrid.ItemsSource = employeers.GetData();
            login.ItemsSource = logins.GetData();
            login.DisplayMemberPath = "login";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || surname.Text == "" || login.Text == "")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                var cell = (login.SelectedItem as DataRowView).Row[0];
                employeers.InsertQuery(name.Text, surname.Text, Convert.ToInt32(cell));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = employeers.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || surname.Text == "" || login.Text == "")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                var cell = (login.SelectedItem as DataRowView).Row[0];
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                employeers.UpdateQuery(name.Text, surname.Text, Convert.ToInt32(cell), Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = employeers.GetData();
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
                employeers.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = employeers.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid.SelectedIndex != -1) 
            { 
                name.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                surname.Text = (DataGrid.SelectedItem as DataRowView).Row[2].ToString();
                login.Text = (DataGrid.SelectedItem as DataRowView).Row[3].ToString();
            }
            else if(DataGrid.SelectedIndex > DataGrid.Items.Count) 
            {
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
