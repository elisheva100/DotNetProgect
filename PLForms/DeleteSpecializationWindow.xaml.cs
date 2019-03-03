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
    /// Interaction logic for DeleteSpecializationWindow.xaml
    /// </summary>
    public partial class DeleteSpecializationWindow : Window
    {
        IBL bl;
        Specialization s;
        long num;

        public DeleteSpecializationWindow()
        {
            InitializeComponent();
            s = new Specialization();
            bl = factoryBL.getBL();
            this.grid1.DataContext = s;
            this.specializationNumberComboBox.ItemsSource = from s1 in bl.GetAllSpecialization()
                                                           select s1.number;
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteSpecialization(s);
                MessageBox.Show("Deleted successfully \n\n" + s.ToString());
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

        private void specializationNumberTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                num = long.Parse(specializationNumberComboBox.SelectedValue.ToString());
                s = this.bl.getSpecialization(num);
                this.grid1.DataContext = s;
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
