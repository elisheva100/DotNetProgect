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
    /// Interaction logic for EmployersWindow.xaml
    /// </summary>
    public partial class EmployersWindow : Window
    {
        public EmployersWindow()
        {
            InitializeComponent();
        }

        private void AddEmployerBotton_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployerWindow().ShowDialog();
        }

        private void deleteEmployerBotton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteEmployerWindow().ShowDialog();
        }

        private void updateEmployerBotton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateEmployerWindow().ShowDialog();
        }

        private void All_EmployersBotton_Click(object sender, RoutedEventArgs e)
        {
            new AllEmployersWindow().Show();
        }
    }
}
