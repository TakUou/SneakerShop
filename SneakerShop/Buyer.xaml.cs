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
    /// Логика взаимодействия для Buyer.xaml
    /// </summary>
    public partial class Buyer : Page
    {
        BuyerTableAdapter buyer = new BuyerTableAdapter();
        public Buyer()
        {
            InitializeComponent();
            DataGrid.ItemsSource = buyer.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || surname.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                buyer.UpdateQuery(name.Text, surname.Text, Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = buyer.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex == -1)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                var id = (DataGrid.SelectedItem as DataRowView).Row[0];
                buyer.DeleteQuery(Convert.ToInt32(id));
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = buyer.GetData();
                DataGrid.SelectedIndex = -1;
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || surname.Text=="")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                buyer.InsertQuery(name.Text,surname.Text);
                DataGrid.ItemsSource = null;
                DataGrid.ItemsSource = buyer.GetData();
                DataGrid.SelectedIndex = -1;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataGrid.SelectedIndex != -1) 
            { 
                name.Text = (DataGrid.SelectedItem as DataRowView).Row[1].ToString();
                surname.Text = (DataGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
            if (DataGrid.SelectedIndex > DataGrid.Items.Count) 
            {
                DataGrid.SelectedIndex = -1;
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string name = openFileDialog.FileName;
            List<Model1> model = MySerializator.MyDeserializer<List<Model1>>(name);
            foreach (var item in model)
            {
                buyer.InsertQuery(item.name, item.surname);
            }
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = buyer.GetData();
            DataGrid.SelectedIndex = -1;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<Model1> list = new List<Model1>();
            var rows = buyer.GetData().Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                Model1 m = new Model1();
                m.name = (rows[i][1]).ToString();
                m.surname = (rows[i][2]).ToString();
                list.Add(m);
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.ShowDialog();
            string nameFile = saveFile.FileName;
            MySerializator.MySerializer(list, nameFile);

        }
    }
}
