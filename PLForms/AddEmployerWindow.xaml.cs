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
    /// Interaction logic for addEmployerWindow.xaml
    /// </summary>
    public partial class AddEmployerWindow : Window
    {
        IBL bl;
        Employer emp;
        public AddEmployerWindow()
        {
            InitializeComponent();
            emp = new Employer();
            bl = factoryBL.getBL();
            this.grid1.DataContext = emp;
            this.specialityComboBox.ItemsSource = Enum.GetValues(typeof(Enums.job));
            //this.foundationDatePicker.Text = DateTime.Now.ToString();
            this.companyNameTextBox.IsEnabled = false;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addEmployer(emp);
                MessageBox.Show("Added successfully \n\n" + emp.ToString());
                emp = new Employer();
                this.grid1.DataContext = emp;
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
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.budgetTextBox.Clear();
            this.cityTextBox.Clear();
            this.companyNameTextBox.Clear();
            this.firstNameTextBox.Clear();
            this.idOrNumberTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.telNumberTextBox.Clear();
        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void companyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.companyNameTextBox.IsEnabled = true;
            this.firstNameTextBox.IsEnabled = false;
            this.lastNameTextBox.IsEnabled = false;
        }

        private void companyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.companyNameTextBox.IsEnabled = false;
            this.firstNameTextBox.IsEnabled = true;
            this.lastNameTextBox.IsEnabled = true;

        }
    }
}
