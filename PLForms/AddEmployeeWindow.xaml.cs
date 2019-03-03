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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        IBL bl;
        Employee em;
        public AddEmployeeWindow()
        {
            InitializeComponent();
            em = new Employee();
            bl = factoryBL.getBL();
            this.grid1.DataContext = em;
            this.dComboBox.ItemsSource = Enum.GetValues(typeof(Enums.degree));
            this.specializationNumberComboBox.ItemsSource = from s in bl.GetAllSpecialization()
                                                            select s.number;
            this.bankNumComboBox.ItemsSource = (from v in bl.GetAllAcounts()
                                                select v.BankNum).Distinct();
            this.bankNameComboBox.ItemsSource = (from v in bl.GetAllAcounts()
                                                 select v.BankName).Distinct();
            this.bankAdressComboBox.ItemsSource = (from v in bl.GetAllAcounts()
                                                   select v.BankAdress).Distinct();
            this.bankBranchComboBox.ItemsSource = (from v in bl.GetAllAcounts()
                                                   select v.BankBranch).Distinct();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                em.details = new BankAccount(Int32.Parse(this.bankNumComboBox.Text), this.bankNameComboBox.Text, int.Parse(this.bankBranchComboBox.Text), this.bankAdressComboBox.Text);
                bl.addEmployee(em);
                string str = bl.gift(em);
                MessageBox.Show("Added successfully \n\n" + em.ToString());
                if (str != "")
                    MessageBox.Show(str);

                em = new Employee();
                this.grid1.DataContext = em;
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
            this.cityTextBox.Clear();
            this.experienceTextBox.Clear();
            this.firstNameTextBox.Clear();
            this.hoursPerMonthTextBox.Clear();
            this.idTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.phoneNumberTextBox.Clear();
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // employeeViewSource.Source = [generic data source]
        }

        private void bankNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void phoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
