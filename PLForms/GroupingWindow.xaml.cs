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
    /// Interaction logic for GroupingWindow.xaml
    /// </summary>
    public partial class GroupingWindow : Window
    {

        IBL bl;
        public GroupingWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();

        }
        private void GroupEmployeeByCarButton_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {

                CarUserControl uc = new CarUserControl();
                uc.Source = bl.EmployeesByCars(order);
                this.page.Content = uc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupContBySpecialButton_Click(object sender, RoutedEventArgs e)

        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                SpecUserControl uc = new SpecUserControl();
                uc.Source = bl.ContractsBySpecializations(order);
                this.page.Content = uc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupContractByCityButton_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                CityUserControl uc = new CityUserControl();
                uc.Source = bl.ContractsByEmployerCity(order);
                this.page.Content = uc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupProfitsByYearButton_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                YearUserControl uc = new YearUserControl();
                uc.Source = bl.ContractsByYearProfit(order);

                this.page.Content = uc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
