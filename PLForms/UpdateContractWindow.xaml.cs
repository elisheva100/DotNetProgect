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
    /// Interaction logic for UpdateContractWindow.xaml
    /// </summary>
    public partial class UpdateContractWindow : Window
    {
        IBL bl;
        Contract c;
        long num;
        public UpdateContractWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();
            c = new Contract();
            this.grid1.DataContext = c;
            this.numberComboBox.ItemsSource = from c1 in bl.GetAllContract()
                                              select c1.number;
            this.employeeIdComboBox.ItemsSource = from c1 in bl.GetAllContract()
                                                  select c1.EmployeeId;
            this.employerIdComboBox.ItemsSource = from c1 in bl.GetAllContract()
                                                  select c1.EmployerId;
            this.finalDatePicker.Text = DateTime.Now.ToString();
            
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //this.numberTextBox.Clear();
            this.brutoSalaryTextBox.Clear();

            this.numberOfHoursTextBox.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.grid1.DataContext = c;
                bl.updateContract(c);
                MessageBox.Show("Updatated successfully \n\n" + c.ToString());
                this.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"",MessageBoxButton.OK,MessageBoxImage.Error);
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
