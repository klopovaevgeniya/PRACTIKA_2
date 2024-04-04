using System;
using System.Collections.Generic;
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

namespace PRACTIKA_2
{
    public partial class WindowEF2 : Window
    {
        private teremok1Entities1 teremok = new teremok1Entities1 ();
        public WindowEF2()
        {
            InitializeComponent();
            BlinGrid.ItemsSource = teremok.blini.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowEF1 window = new WindowEF1();
            window.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowEF3 window = new WindowEF3();
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            blini i = new blini();
            i.nameblin = NameBlinBox.Text;
            i.price = Convert.ToDecimal(PriceBox.Text);
            teremok.blini.Add(i);
            teremok.SaveChanges();
            BlinGrid.ItemsSource = teremok.blini.ToList();
            NameBlinBox.Clear();
            PriceBox.Clear();
        }

        private void BlinGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BlinGrid.SelectedItem != null)
            {
                var selected = BlinGrid.SelectedItem as blini;
                NameBlinBox.Text = selected.nameblin;
                PriceBox.Text = selected.price.ToString();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (BlinGrid.SelectedItem != null)
            {
                var selected = BlinGrid.SelectedItem as blini;
                selected.nameblin = NameBlinBox.Text;
                selected.price = Convert.ToDecimal(PriceBox.Text);
                teremok.SaveChanges();
                BlinGrid.ItemsSource = teremok.blini.ToList();
                NameBlinBox.Clear();
                PriceBox.Clear();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (BlinGrid.SelectedItem != null)
            {
                teremok.blini.Remove(BlinGrid.SelectedItem as blini);
                teremok.SaveChanges();
                BlinGrid.ItemsSource = teremok.blini.ToList();
                NameBlinBox.Clear();
                PriceBox.Clear();
            }
        }
    }
}
