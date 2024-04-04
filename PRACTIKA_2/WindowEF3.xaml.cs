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
    public partial class WindowEF3 : Window
    {
        private teremok1Entities1 teremok = new teremok1Entities1();
        public WindowEF3()
        {
            InitializeComponent();
            ZakazGrid.ItemsSource = teremok.zakaz.ToList();
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
            WindowEF2 window = new WindowEF2();
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            zakaz i = new zakaz();
            i.numberzakaz = NumberZakazBox.Text;
            i.blin_ID = Convert.ToInt32(ID_blinBox.Text);
            i.employee_ID = Convert.ToInt32(ID_employeeBox.Text);
            teremok.zakaz.Add(i);
            teremok.SaveChanges();
            ZakazGrid.ItemsSource = teremok.blini.ToList();
            NumberZakazBox.Clear();
            ID_blinBox.Clear();
            ID_employeeBox.Clear();
        }

        private void ZakazGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ZakazGrid.SelectedItem != null)
            {
                var selected = ZakazGrid.SelectedItem as zakaz;
                NumberZakazBox.Text = selected.numberzakaz;
                ID_blinBox.Text = selected.blin_ID.ToString();
                ID_employeeBox.Text = selected.employee_ID.ToString();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ZakazGrid.SelectedItem != null)
            {
                var selected = ZakazGrid.SelectedItem as zakaz;
                selected.numberzakaz = NumberZakazBox.Text;
                selected.blin_ID = Convert.ToInt32(ID_blinBox.Text);
                selected.employee_ID = Convert.ToInt32(ID_employeeBox.Text);
                teremok.SaveChanges();
                ZakazGrid.ItemsSource = teremok.zakaz.ToList();
                NumberZakazBox.Clear();
                ID_blinBox.Clear();
                ID_employeeBox.Clear();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ZakazGrid.SelectedItem != null)
            {
                teremok.zakaz.Remove(ZakazGrid.SelectedItem as zakaz);
                teremok.SaveChanges();
                ZakazGrid.ItemsSource = teremok.zakaz.ToList();
                NumberZakazBox.Clear();
                ID_blinBox.Clear();
                ID_employeeBox.Clear();
            }
        }
    }
}
