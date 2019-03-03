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
using BL;
using BE;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployeeWindow : Window
    {
        IBL bl;
        Employee em;
        string id;
        public UpdateEmployeeWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();
            em = new Employee();
            this.grid1.DataContext = em;
            this.idComboBox.ItemsSource = from e in bl.GetAllEmployee()
                                          select e.Id;
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



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            this.cityTextBox.Clear();
            this.experienceTextBox.Clear();
            this.firstNameTextBox.Clear();
            this.hoursPerMonthTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.phoneNumberTextBox.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.grid1.DataContext = em;

                bl.updateEmployee(em);
                MessageBox.Show("Updatated successfully \n\n" + em.ToString());
                string str = bl.gift(em);
                if (str != "")
                    MessageBox.Show(str);
                this.Close();

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


        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = idComboBox.SelectedValue.ToString();
                em = this.bl.getEmployee(id);
                this.grid1.DataContext = em;


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

        private void bankNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void specializationNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contract co = (from c in bl.GetAllContract()
                            where c.EmployeeId == em.Id
                            select c).FirstOrDefault();
            if (co != null)
            {
                this.specializationNumberComboBox.IsEditable = false;
                this.specializationNumberComboBox.IsHitTestVisible = false;
                this.specializationNumberComboBox.Focusable = false;

            }
        }
    }
}
