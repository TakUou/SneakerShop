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
using Microsoft.Win32;
using SneakerShop.SneakerShopDataSetTableAdapters;

namespace SneakerShop
{
    /// <summary>
    /// Логика взаимодействия для StockSneakers.xaml
    /// </summary>
    public partial class StockSneakers : Page
    {
        FirmTableAdapter firm = new FirmTableAdapter();
        CountryTableAdapter country = new CountryTableAdapter();
        ProviderTableAdapter provider = new ProviderTableAdapter();
        SneakersTableAdapter sneakers = new SneakersTableAdapter();
        public StockSneakers()
        {
            InitializeComponent();
            DataGrid.ItemsSource = sneakers.GetData();
            firmcb.ItemsSource = firm.GetData();
            firmcb.DisplayMemberPath = "name_firm";
            countrycb.ItemsSource = country.GetData();
            countrycb.DisplayMemberPath = "name_country";
            providercb.ItemsSource = provider.GetData();
            providercb.DisplayMemberPath = "name_privider";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<Model> list = new List<Model>();
            var rows = sneakers.GetData().Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                Model m = new Model();
                m.firm_id = Convert.ToInt32(rows[i][1]);
                m.country_id = Convert.ToInt32(rows[i][2]);
                m.provider_id = Convert.ToInt32(rows[i][3]);
                m.name = Convert.ToString(rows[i][4]);
                m.cost = Convert.ToInt32(rows[i][5]);
                list.Add(m);
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.ShowDialog();
            string nameFile = saveFile.FileName;
            MySerializator.MySerializer(list, nameFile);   

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string name = openFileDialog.FileName;
            List<Model> model = MySerializator.MyDeserializer<List<Model>>(name);
            foreach (var item in model)
            {
                sneakers.InsertQuery(item.firm_id, item.country_id, item.provider_id, item.name, item.cost);
            }
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = sneakers.GetData();
            DataGrid.SelectedIndex = -1;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedIndex != -1)
            {
                firmcb.SelectedItem = (DataGrid.SelectedItem as DataRowView).Row[3];
                countrycb.SelectedItem = (DataGrid.SelectedItem as DataRowView).Row[4];
                providercb.SelectedItem = (DataGrid.SelectedItem as DataRowView).Row[5];
                nameSneakers.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                cost.Text = (DataGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
            if(DataGrid.SelectedIndex > DataGrid.Items.Count)
            {
                DataGrid.SelectedIndex = -1;
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cost.Text.Length; i++)
            {
                if (!(cost.Text[i] >= '0' && cost.Text[i] <= '9'))
                {
                    MessageBox.Show("Поле не должно содержать символы!");
                    break;
                }
            }
            if (firmcb.Text == "" || countrycb.Text == "" || providercb.Text == "" || cost.Text == "" || nameSneakers.Text == "")
            {
                MessageBox.Show("Не все поля имеют значения");
            }
            else
            {
                var cell = (firmcb.SelectedItem as DataRowView).Row[0];
                var cell1 = (countrycb.SelectedItem as DataRowView).Row[0];
                var cell2 = (providercb.SelectedItem as DataRowView).Row[0];
                sneakers.InsertQuery(Convert.ToInt32(cell), Convert.ToInt32(cell1), Convert.ToInt32(cell2), nameSneakers.Text, Convert.ToInt32(cost.Text));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = sneakers.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cost.Text.Length; i++)
            {
                if (!(cost.Text[i] >= '0' && cost.Text[i] <= '9'))
                {
                    MessageBox.Show("Поле не должно содержать символы!");
                    break;
                }
            }
            if (firmcb.Text == "" || countrycb.Text == "" || providercb.Text == "" || cost.Text == "" || nameSneakers.Text == "")
            {
                MessageBox.Show("Не все поля имеют значения");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                var cell = (firmcb.SelectedItem as DataRowView).Row[0];
                var cell1 = (countrycb.SelectedItem as DataRowView).Row[0];
                var cell2 = (providercb.SelectedItem as DataRowView).Row[0];
                sneakers.UpdateQuery(Convert.ToInt32(cell), Convert.ToInt32(cell1), Convert.ToInt32(cell2), nameSneakers.Text, Convert.ToInt32(cost.Text), Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = sneakers.GetData();
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
                sneakers.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = sneakers.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }
    }
}
