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
using System.Windows.Shapes;
using PRACTIKA_2.teremok1DataSetTableAdapters;

namespace PRACTIKA_2
{
    public partial class WindowDS3 : Window
    {
        zakazTableAdapter zakaz = new zakazTableAdapter();
        public WindowDS3()
        {
            InitializeComponent();
            ZakazGrid.ItemsSource = zakaz.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowDS1 window = new WindowDS1();
            window.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowDS2 window = new WindowDS2();
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var numberzakaz = NumberZakazBox.Text;
            var blin_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
            var employee_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
            zakaz.InsertQuery(numberzakaz, blin_ID, employee_ID);
            ZakazGrid.ItemsSource = zakaz.GetData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ZakazGrid.SelectedItem != null)
            {
                var original_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
                var numberzakaz = NumberZakazBox.Text;
                var blin_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
                var employee_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
                zakaz.UpdateQuery(numberzakaz, blin_ID, employee_ID, original_ID);
                ZakazGrid.ItemsSource= zakaz.GetData();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var original_ID = Convert.ToInt32((ZakazGrid.SelectedItem as DataRowView).Row[0]);
            zakaz.DeleteQuery(original_ID);
            ZakazGrid.ItemsSource = zakaz.GetData();
        }

        private void ZakazGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ZakazGrid.SelectedItem != null)
            {
                NumberZakazBox.Text = (ZakazGrid.SelectedItem as DataRowView).Row[1].ToString();
                ID_BlinBox.Text = (ZakazGrid.SelectedItem as DataRowView).Row[2].ToString();
                ID_employeeBox.Text = (ZakazGrid.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
