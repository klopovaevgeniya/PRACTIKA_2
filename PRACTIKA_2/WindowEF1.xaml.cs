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
    public partial class WindowEF1 : Window
    {
        private teremok1Entities1 teremok = new teremok1Entities1 ();
        public WindowEF1()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = teremok.employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowEF2 windowEF2 = new WindowEF2();
            windowEF2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowEF3 windowEF3 = new WindowEF3();
            windowEF3.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            employee i = new employee ();
            i.firstname = FirstnameBox.Text;
            i.surname = SurnameBox.Text;
            i.email = EmailBox.Text;
            teremok.employee.Add (i);
            teremok.SaveChanges();
            EmployeeGrid.ItemsSource = teremok.employee.ToList();
            FirstnameBox.Clear();
            SurnameBox.Clear();
            EmailBox.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as employee; 
                selected.firstname = FirstnameBox.Text;
                selected.surname= SurnameBox.Text;
                selected.email = EmailBox.Text;
                teremok.SaveChanges ();
                EmployeeGrid.ItemsSource = teremok.employee.ToList();
                FirstnameBox.Clear ();
                SurnameBox.Clear ();
                EmailBox.Clear ();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                teremok.employee.Remove(EmployeeGrid.SelectedItem as employee);
                teremok.SaveChanges();
                EmployeeGrid.ItemsSource = teremok.employee.ToList();
                FirstnameBox.Clear();
                SurnameBox.Clear();
                EmailBox.Clear();
            }
        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var selected = EmployeeGrid.SelectedItem as employee;
                FirstnameBox.Text = selected.firstname;
                SurnameBox.Text = selected.surname;
                EmailBox.Text = selected.email;
            }
        }
    }
}
