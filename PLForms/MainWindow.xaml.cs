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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = factoryBL.getBL();

            //Specialization
            //Specialization s1 = new Specialization { name = "C++", minCost = 100, maxCost = 150, minHours = 50, speciality = Enums.job.communication };
            //Specialization s2 = new Specialization { name = "c#", minCost = 35, maxCost = 68, minHours = 80, speciality = Enums.job.dataBase };
            //bl.addSpecialization(s1);
            //bl.addSpecialization(s2);

            // Employee
            //bl.addEmployee(new Employee { Id = "208833012", firstName = "Avi", lastName = "Cohen", phoneNumber = "0536582322", experience = 8, city = "Jerusalem", SpecializationNumber = 10000000, hoursPerMonth = 120, dateBirth = new DateTime(1990, 05, 01), AcountNumber = 111,/*details = new BankAccount(1, "Leumi", 100, "11 Jaffa street", "Jerusalem", 1000),*/ d = Enums.degree.BA });
            //bl.addEmployee(new Employee { Id = "303097117", firstName = "Moshe", lastName = "Levi", phoneNumber = "0543906754", experience = 30, city = "Jerusalem", SpecializationNumber = 10000001, hoursPerMonth = 130, dateBirth = new DateTime(1967, 08, 06), AcountNumber = 222,/* details = new BankAccount(1, "Pagy", 400, "44 Shaul street", "Jerusalem", 4000),*/ d = Enums.degree.diploma });

            // Employer
            //bl.addEmployer(new Employer { CompanyName = "Google", company = true, city = "Tel Aviv", telNumber = "5558976", foundation = new DateTime(1984, 08, 02), idOrNumber = "205374507", speciality = Enums.job.communication });
            //bl.addEmployer(new Employer { firstName = "Jacobe", lastName = "Davidson", company = false, city = "Tel Aviv", telNumber = "6898976", foundation = new DateTime(1995, 08, 02), idOrNumber = "068340090", speciality = Enums.job.dataBase });

            //Contract
            //bl.addContract(new Contract { beginning = DateTime.Now, final = new DateTime(2020, 09, 03), EmployeeId = "208833012", EmployerId = "205374507", brutoSalary = 15000, numberOfHours = 120 });
            //bl.addContract(new Contract { beginning = DateTime.Now, final = new DateTime(2018, 06, 11), EmployeeId = "303097117", EmployerId = "068340090", brutoSalary = 10000, numberOfHours = 150 });



        }

        private void SpecialzitationsButton_Click(object sender, RoutedEventArgs e)
        {
            SpecializationWindow s =  new SpecializationWindow();
            s.Show();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesWindow em = new EmployeesWindow();
            em.Show();
        }

        private void EmployersButton_Click(object sender, RoutedEventArgs e)
        {
            EmployersWindow emp =  new EmployersWindow();
            emp.Show();
        }

        private void ContractsButton_Click(object sender, RoutedEventArgs e)
        {
            ContractsWindow c =  new ContractsWindow();
            c.Show();
        }

        private void Groping_Click(object sender, RoutedEventArgs e)
        {
            new GroupingWindow().Show();
        }
    }
}
