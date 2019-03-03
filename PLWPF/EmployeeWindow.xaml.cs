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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        BE.Employee em;
        BL.IBL bl;
        public  AddEmployee()
        {
            InitializeComponent();
            em = new BE.Employee();
            this.EmployeeDetailsGrid.DataContext = em;
            bl = BL.factoryBL.getBL();

        }

        private void idTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                em.Id = (this.idTextBox.Text);
                em.lastName = this.nameTextBox.Text;
                bl.addEmployee(em);
                em = new BE.Employee();
                this.idTextBox.ClearValue(TextBox.TextProperty);
                }
                 catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}


