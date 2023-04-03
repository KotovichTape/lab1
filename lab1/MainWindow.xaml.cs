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
using lab1.masterDataSetTableAdapters;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HumanTableAdapter Human = new HumanTableAdapter();
        ColourTableAdapter colour = new ColourTableAdapter();
        
        public MainWindow()
        {
            InitializeComponent();
            HumanDataGrid.ItemsSource = Human.GetData();
            //HumanDataGrid.DisplayMemberPath = "Name";
            Familia.ItemsSource = colour.GetData();
            Familia.DisplayMemberPath = "Name";
            Familia.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.ShowDialog(); 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Human.InsertQuery(HumanTbx.Text, Convert.ToInt32(Familia.SelectedValue));
            HumanDataGrid.ItemsSource = Human.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (HumanDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку, которую хотите удалить");
                return;
            }
            else
            {
                object id = (HumanDataGrid.SelectedItem as DataRowView).Row[0];
                Human.DeleteQuery(Convert.ToInt32(id));
                HumanDataGrid.ItemsSource = Human.GetData();
            }

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (HumanDataGrid.SelectedItem as DataRowView).Row[0];
            Human.UpdateQuery(HumanTbx.Text, (int)Familia.SelectedValue ,Convert.ToInt32(id));
            HumanDataGrid.ItemsSource = Human.GetData();    

        }

        private void HumanDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(HumanDataGrid.SelectedItem != null)
            {
                HumanTbx.Text = (string)(HumanDataGrid.SelectedItem as DataRowView).Row[1];
                Familia.SelectedValue = (HumanDataGrid.SelectedItem as DataRowView).Row[2];
            }

            
        }
    }
}
