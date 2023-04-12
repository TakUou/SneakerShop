using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using SneakerShop.SneakerShopDataSetTableAdapters;

namespace SneakerShop
{
    /// <summary>
    /// Логика взаимодействия для AdminPage3.xaml
    /// </summary>
    public partial class AdminPage3 : Page
    {
        LoginTableAdapter logins = new LoginTableAdapter();
        roleTableAdapter role = new roleTableAdapter();
        public AdminPage3()
        {
            InitializeComponent();
            DataGrid.ItemsSource = logins.GetData();
            roles.ItemsSource = role.GetData();
            roles.DisplayMemberPath = "name_role";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Text == "" || roles.Text=="")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                var cell = (roles.SelectedItem as DataRowView).Row[0];
                logins.InsertQuery(login.Text, password.Text, Convert.ToInt32(cell));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = logins.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Text == "" || roles.Text == "")
            {
                MessageBox.Show("Какое-то поле пусто! Проверьте поля на их заполнение.");
            }
            else
            {
                var cell = (roles.SelectedItem as DataRowView).Row[0];
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                logins.UpdateQuery(login.Text, password.Text, Convert.ToInt32(cell), Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = logins.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите поле для удаления!");
            }
            var id = (DataGrid.SelectedItem as DataRowView).Row[0];
            logins.DeleteQuery(Convert.ToInt32(id));
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = logins.GetData();
            DataGrid.SelectedIndex = -1;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid.SelectedIndex != -1)
            {
                login.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                password.Text = (DataGrid.SelectedItem as DataRowView).Row[2].ToString();
                roles.SelectedItem = (DataGrid.SelectedItem as DataRowView).Row[3];
            }
            else if(DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
