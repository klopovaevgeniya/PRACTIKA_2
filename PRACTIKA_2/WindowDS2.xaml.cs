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
    public partial class WindowDS2 : Window
    {
        bliniTableAdapter blin = new bliniTableAdapter();
        public WindowDS2()
        {
            InitializeComponent();
            BlinGrid.ItemsSource = blin.GetData();
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
            WindowDS3 window = new WindowDS3();
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var nameblin = NameBlinBox.Text;
            var price = PriceBox.Text;
            blin.InsertQuery(nameblin, Convert.ToDecimal(price));
            BlinGrid.ItemsSource = blin.GetData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (BlinGrid.SelectedItem != null)
            {
                var original_ID = Convert.ToInt32((BlinGrid.SelectedItem as DataRowView).Row[0]);
                var nameblin = NameBlinBox.Text;
                var price = PriceBox.Text;
                blin.UpdateQuery(nameblin, Convert.ToDecimal(price), original_ID);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var original_ID = Convert.ToInt32((BlinGrid.SelectedItem as DataRowView).Row[0]);
            blin.DeleteQuery(original_ID);
            BlinGrid.ItemsSource = blin.GetData();
        }

        private void BlinGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BlinGrid.SelectedItem != null)
            {
                NameBlinBox.Text = (BlinGrid.SelectedItem as DataRowView).Row[1].ToString();
                PriceBox.Text = (BlinGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
        }
    }
}
