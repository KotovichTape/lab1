using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lab1.masterDataSetTableAdapters;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ColourTableAdapter Color = new ColourTableAdapter();
        public Window1()
        {
            InitializeComponent();
            ColorDataGrid.ItemsSource = Color.GetData();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Color.InsertQuery(ColorTbx.Text);
          //  ColorDataGrid.ItemsSource = null;
            ColorDataGrid.ItemsSource = Color.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ColorDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (ColorDataGrid.SelectedItem as DataRowView).Row[0];
                Color.DeleteQuery(Convert.ToInt32(id));
                ColorDataGrid.ItemsSource = Color.GetData();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (ColorDataGrid.SelectedItem as DataRowView).Row[0];
            Color.UpdateQuery(ColorTbx.Text, Convert.ToInt32(id));
            ColorDataGrid.ItemsSource = Color.GetData();
        }

        private void ColorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorDataGrid.SelectedItem != null)
            {
                ColorTbx.Text = (string)(ColorDataGrid.SelectedItem as DataRowView).Row[1];
                
            }

        }
    }
}
