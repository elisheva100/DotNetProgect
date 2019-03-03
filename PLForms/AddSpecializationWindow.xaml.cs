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
    /// Interaction logic for AddSpecializationWindow.xaml
    /// </summary>
    public partial class AddSpecializationWindow : Window
    {
        IBL bl;
        Specialization s;
        public AddSpecializationWindow()
        {
            InitializeComponent();
            s = new Specialization();
            bl = factoryBL.getBL();
            this.grid1.DataContext = s;
            this.specialityComboBox.ItemsSource = Enum.GetValues(typeof(Enums.job));
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.maxCostTextBox.Clear();
            this.minHoursTextBox.Clear();
            this.minCostTextBox.Clear();
        

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addSpecialization(s);
                MessageBox.Show("Added successfully \n\n" + s.ToString());
                s = new Specialization();
                this.grid1.DataContext = s;
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
    }
}
