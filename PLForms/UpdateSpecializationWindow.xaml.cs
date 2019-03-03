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
    /// Interaction logic for UpdateSpecializationWindow.xaml
    /// </summary>
    public partial class UpdateSpecializationWindow : Window
    {
        IBL bl;
        Specialization s;
        long num;
        public UpdateSpecializationWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();
            s = new Specialization();
            this.grid1.DataContext = s;
            this.specialityComboBox.ItemsSource = Enum.GetValues(typeof(Enums.job));
            this.numberComboBox.ItemsSource = from s1 in bl.GetAllSpecialization()
                                                  select s1.number;
            
        }
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.maxCostTextBox.Clear();
            this.minCostTextBox.Clear();
            this.minHoursTextBox.Clear();
            this.nameTextBox.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.grid1.DataContext = s;
                bl.updateSpecialization(s);
                MessageBox.Show("Updatated successfully \n\n" + s.ToString());
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

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                num = long.Parse(numberComboBox.SelectedValue.ToString());
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
