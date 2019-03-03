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
    /// Interaction logic for UpdateEmployerWindow.xaml
    /// </summary>
    public partial class UpdateEmployerWindow : Window
    {
        IBL bl;
        Employer emp;
        string id;
        public UpdateEmployerWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();
            emp = new Employer();
            this.grid1.DataContext = emp;
            this.idOrNumberComboBox.ItemsSource = from e in bl.GetAllEmployer()
                                                  select e.idOrNumber;
            this.specialityComboBox.ItemsSource = Enum.GetValues(typeof(Enums.job));
            //this.foundationDatePicker.DataContext = DateTime.Now;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource employerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // employerViewSource.Source = [generic data source]
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            this.budgetTextBox.Clear();
            this.cityTextBox.Clear();
            this.companyNameTextBox.Clear();
            this.firstNameTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.telNumberTextBox.Clear();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.grid1.DataContext = emp;
                bl.updateEmployer(emp);
                MessageBox.Show("Updatated successfully \n\n" + emp.ToString());
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

        private void idOrNumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = idOrNumberComboBox.SelectedValue.ToString();
                emp = this.bl.getEmployer(id);
                this.grid1.DataContext = emp;
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

        private void companyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.firstNameTextBox.IsEnabled = false;
            this.lastNameTextBox.IsEnabled = false;
        }
        private void companyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.companyNameTextBox.Text = "";
            this.firstNameTextBox.IsEnabled = true;
            this.lastNameTextBox.IsEnabled = true;

        }

        private void specialityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contract co = (from c in bl.GetAllContract()
                           where c.EmployerId == emp.idOrNumber
                           select c).FirstOrDefault();
            if (co != null)
            {
                this.specialityComboBox.IsEditable = false;
                this.specialityComboBox.IsHitTestVisible = false;
                this.specialityComboBox.Focusable = false;
            }
        }
    }
}
