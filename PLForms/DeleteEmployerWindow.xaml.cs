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
    /// Interaction logic for DeleteEmployerWindow.xaml
    /// </summary>
    public partial class DeleteEmployerWindow : Window
    {
        IBL bl;
        Employer emp;
        string id;
        public DeleteEmployerWindow()
        {
            InitializeComponent();
            emp = new Employer();
            bl = factoryBL.getBL();
            this.grid1.DataContext = emp;
            this.idOrNumberComboBox.ItemsSource = from em in bl.GetAllEmployer()
                                          select em.idOrNumber;
        }

       

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.deleteEmployer(emp);
                MessageBox.Show("Deleted successfully \n\n" + emp.ToString());
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
