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

namespace PLForms
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        public EmployeesWindow()
        {
            InitializeComponent();
        }

        private void AddEmployeeBotton_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeWindow().ShowDialog();
        }

        private void deleteEmployeeBotton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteEmployeeWindow().ShowDialog();
        }

        private void updateEmployeeBotton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateEmployeeWindow().ShowDialog();
        }

        private void All_EmployeesBotton_Click(object sender, RoutedEventArgs e)
        {
            new AllEmployeesWindow().Show();
        }
    }
}
