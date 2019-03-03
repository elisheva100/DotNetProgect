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
    /// Interaction logic for SpecializationWindow.xaml
    /// </summary>
    public partial class SpecializationWindow : Window
    {
        public SpecializationWindow()
        {
            InitializeComponent();
        }

        private void AddSpecializtionBotton_Click(object sender, RoutedEventArgs e)
        {
            new AddSpecializationWindow().ShowDialog();
        }

        private void deleteSpecializtionBotton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteSpecializationWindow().ShowDialog();
        }

        private void updateSpecializtionBotton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateSpecializationWindow().ShowDialog();
        }

        private void All_SpecializtionsBotton_Click(object sender, RoutedEventArgs e)
        {
            new AllSpecializationsWindow().Show();
        }
    }
}
