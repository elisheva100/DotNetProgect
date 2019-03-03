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
    /// Interaction logic for DeleteEmployeeWindow.xaml
    /// </summary>
    public partial class DeleteEmployeeWindow : Window
    {
        IBL bl;
        Employee em;
        string id;
        
        public DeleteEmployeeWindow()
        {
            InitializeComponent();
            em = new Employee();
            bl = factoryBL.getBL();
            this.grid1.DataContext = em;
            this.idComboBox.ItemsSource = from e in bl.GetAllEmployee()
                                          select e.Id;
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.deleteEmployee(em);
                MessageBox.Show("Deleted successfully \n\n" + em.ToString());
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
