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
    /// Interaction logic for AddContract.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        IBL bl;
        Contract c;
        public AddContractWindow()
        {
            InitializeComponent();
            c = new Contract();
            bl = factoryBL.getBL();
            this.grid1.DataContext = c;
            this.employeeIdComboBox.ItemsSource = from em in bl.GetAllEmployee()
                                                  select em.Id;

            this.employerIdComboBox.ItemsSource = from emp in bl.GetAllEmployer()
                                                  select emp.idOrNumber;
            //this.beginningDatePicker.Text = DateTime.Now.ToString();
            //this.finalDatePicker.Text = DateTime.Now.ToString();
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String str = bl.addContract(c);
                MessageBox.Show("Added successfully \n\n" + c.ToString() + "\n\n" + str);
                c = new Contract();
                this.grid1.DataContext = c;
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.brutoSalaryTextBox.Clear();
            this.numberOfHoursTextBox.Clear();

        }

    }
}
