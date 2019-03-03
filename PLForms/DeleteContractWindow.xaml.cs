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
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        IBL bl;
        Contract c;
        long num;
        public DeleteContractWindow()
        {
            InitializeComponent();
            
            bl = factoryBL.getBL();
            this.numberComboBox.ItemsSource = from c1 in bl.GetAllContract()
                                  select c1.number;
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteContract(c);
                MessageBox.Show("Deleted successfully \n\n" + c.ToString());
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                num = long.Parse(numberComboBox.SelectedValue.ToString());
                c = this.bl.getContract(num);
                this.grid1.DataContext = c;
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
