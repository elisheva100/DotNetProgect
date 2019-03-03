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
using BE;
using BL;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for AllEmployeesWindow.xaml
    /// </summary>
    public partial class AllEmployeesWindow : Window
    {
        IBL bl;
        public AllEmployeesWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();

            this.listView.ItemsSource = bl.GetAllEmployee();
        }



        private void list_view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
