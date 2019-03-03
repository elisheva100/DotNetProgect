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
    /// Interaction logic for ContractsWindow.xaml
    /// </summary>
    public partial class ContractsWindow : Window
    {
        public ContractsWindow()
        {
            InitializeComponent();
        }

        private void AddContractBotton_Click(object sender, RoutedEventArgs e)
        {
            new AddContractWindow().ShowDialog();
        }

        private void deleteContractBotton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteContractWindow().ShowDialog();
        }

        private void updateContractBotton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateContractWindow().ShowDialog();
        }

        private void All_ContractsBotton_Click(object sender, RoutedEventArgs e)
        {
            new AllContractsWindow().Show();
        }
    }
}
