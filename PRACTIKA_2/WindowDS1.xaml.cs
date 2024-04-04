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
    public partial class WindowDS1 : Window
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        public WindowDS1()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = employee.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowDS2 window = new WindowDS2();
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
                var firstname = FirstnameBox.Text;
                var surname = SurnameBox.Text;
                var email = EmailBox.Text;
                employee.InsertQuery(firstname, surname, email);
                EmployeeGrid.ItemsSource = employee.GetData();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                var original_ID = Convert.ToInt32((EmployeeGrid.SelectedItem as DataRowView).Row[0]);
                var firstname = FirstnameBox.Text;
                var surname = SurnameBox.Text;
                var email = EmailBox.Text;
                employee.UpdateQuery(firstname, surname, email, original_ID);
                EmployeeGrid.ItemsSource = employee.GetData();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var original_ID_employee = Convert.ToInt32((EmployeeGrid.SelectedItem as DataRowView).Row[0]);
            employee.DeleteQuery(original_ID_employee);
            EmployeeGrid.ItemsSource = employee.GetData();

        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem != null)
            {
                FirstnameBox.Text = (EmployeeGrid.SelectedItem as DataRowView).Row[1].ToString();
                SurnameBox.Text = (EmployeeGrid.SelectedItem as DataRowView).Row[2].ToString();
                EmailBox.Text = (EmployeeGrid.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
