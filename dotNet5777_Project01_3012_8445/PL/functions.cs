using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PL
{
    public partial class Program
    {

        #region Specialization functions.
        static void addSpecialization()
        {
            Specialization s = new Specialization();
            Console.WriteLine("Enter Specialization details:");
            Console.WriteLine("Enter Specialization name:");
            String str = Console.ReadLine();
            s.name = (Enums.job)Enum.Parse(typeof(Enums.job), str, true);
            Console.WriteLine("Enter minimum cost:");
            s.minCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum cost:");
            s.maxCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter minimum hours:");
            s.minHours = int.Parse(Console.ReadLine());

            bl.addSpecialization(s);
        }

        static void deleteSpecialization()
        {
            Console.WriteLine("Enter the specialization number that you want to remove");
            long num = long.Parse(Console.ReadLine());

            bl.deleteSpecialization(bl.getSpecialization(num));

        }

        static void updateSpecialization()
        {
            
            Console.WriteLine("Enter Specialization number to update:");
            long num = long.Parse(Console.ReadLine());
            Specialization spe = bl.getSpecialization(num);
            spe.number = num;
            Console.WriteLine("Enter Specialization name:");
            string str = Console.ReadLine();
            spe.name = (Enums.job)Enum.Parse(typeof(Enums.job), str, true);
            Console.WriteLine("Enter minimum cost:");
            spe.minCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum cost:");
            spe.maxCost = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter minimum hours:");
            spe.minHours = int.Parse(Console.ReadLine());

            bl.updateSpecialization(spe);
        }
        static String getSpecialization()
        {
            Console.WriteLine("Enter the number of the specialization you are looking for:");
            long num = long.Parse(Console.ReadLine());
            Specialization s = bl.getSpecialization(num);
            return s.ToString();


        }
        #endregion

        #region Employee functions.
        static void addEmployee()
        {
            Employee em = new Employee();
            Console.WriteLine("Enter employee details:");
            Console.WriteLine("Enter id:");
            em.Id = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            em.firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            em.lastName = Console.ReadLine();
            Console.WriteLine("Enter city:");
            em.city = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            em.dateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter phone Number");
            em.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Specialization");
            string st = Console.ReadLine();
            em.employeeSpecialization = (Enums.job)Enum.Parse(typeof(Enums.job), st, true);
            Console.WriteLine("Enter your degree");
            string str = Console.ReadLine();
            em.d = (Enums.degree)Enum.Parse(typeof(Enums.degree), str, true);
            Console.WriteLine("Enter number of hours per month you can work");
            em.hoursPerMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your experience (by years)");
            em.experience = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bank acount details");
            Console.WriteLine("Enter bank number");
            int bankNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bank's name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter branch number");
            int branchNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter adress");
            string adress = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter bank account number");
            int bankAcountNumber = int.Parse(Console.ReadLine());
            em.details = new BankAccount(bankNumber, name, branchNumber, adress, city, bankAcountNumber);

            bl.addEmployee(em);
            if(em.prize > 0)
            {
                Console.WriteLine(bl.gift());
            }
        }

        static void deleteEmployee()
        {
            Console.WriteLine("Enter the employee's ID that you want to remove");
            string num = Console.ReadLine();

            bl.deleteEmployee(bl.getEmployee(num));

        }
        static void updateEmployee()
        {
            Employee empl = new Employee();
            Console.WriteLine("Enter employee to update:");
            Console.WriteLine("Enter id:");
            empl.Id = Console.ReadLine();
            Console.WriteLine("Enter first name:");
            empl.firstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            empl.lastName = Console.ReadLine();
            Console.WriteLine("Enter city:");
            empl.city = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            empl.dateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter phone Number");
            empl.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Specialization");
            string st = Console.ReadLine();
            Console.WriteLine("Enter your degree");
            string str = Console.ReadLine();
            empl.d = (Enums.degree)Enum.Parse(typeof(Enums.degree), str, true);
            empl.employeeSpecialization = (Enums.job)Enum.Parse(typeof(Enums.job), st, true);
            Console.WriteLine("Enter number of hours per month you can work");
            empl.hoursPerMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your experience (by years)");
            empl.experience = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bank acount details");
            Console.WriteLine("Enter bank number");
            int bankNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bank's name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter branch number");
            int branchNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter adress");
            string adress = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter bank account number");
            int bankAcountNumber = int.Parse(Console.ReadLine());
            empl.details = new BankAccount(bankNumber, name, branchNumber, adress, city, bankAcountNumber);

            bl.updateEmployee(empl);
            if (empl.prize > 0)
            {
                Console.WriteLine(bl.gift());
            }
        }
        static String getEmployee()
        {
            Console.WriteLine("Enter the id of the employee you are looking for:");
            string id = Console.ReadLine();
            Employee em = bl.getEmployee(id);
            return em.ToString();
        }
        #endregion

        #region Employer functions.
        static void addEmployer()
        {
            Employer emp = new Employer();
            Console.WriteLine("Enter employer details:");
            Console.WriteLine("Enter id:");
            emp.idOrNumber = Console.ReadLine();
            Console.WriteLine("Are you a compny? (YES/NO)");
            string answer = Console.ReadLine();
            if (answer == "YES")
            {
                emp.company = true;
                Console.WriteLine("Enter company name");
                emp.CompanyName = Console.ReadLine();
            }
            else
            {
                emp.company = false;
                Console.WriteLine("Enter first name:");
                emp.firstName = Console.ReadLine();
                Console.WriteLine("Enter last name:");
                emp.lastName = Console.ReadLine();
            }
            Console.WriteLine("Enter city:");
            emp.city = Console.ReadLine();
            Console.WriteLine("Enter foundation time");
            emp.foundation = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter tel number");
            emp.telNumber = Console.ReadLine();

            bl.addEmployer(emp);

        }
        static void deleteEmployer()
        {
            Console.WriteLine("Enter the employer's ID that you want to remove");
            string num = Console.ReadLine();

            bl.deleteEmployer(bl.getEmployer(num));

        }
        static void updateEmployer()
        {
            Employer emplo = new Employer();
            Console.WriteLine("Enter employer to update:");
            Console.WriteLine("Enter id:");
            emplo.idOrNumber = Console.ReadLine();
            Console.WriteLine("Are you a compny? (YES/NO)");
            string answer = Console.ReadLine();
            if (answer == "YES")
            {
                emplo.company = true;
                Console.WriteLine("Enter company name");
                emplo.CompanyName = Console.ReadLine();
            }
            else
            {
                emplo.company = false;
                Console.WriteLine("Enter first name:");
                emplo.firstName = Console.ReadLine();
                Console.WriteLine("Enter last name:");
                emplo.lastName = Console.ReadLine();
            }
            Console.WriteLine("Enter city:");
            emplo.city = Console.ReadLine();
            Console.WriteLine("Enter foundation time");
            emplo.foundation = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter tel number");
            emplo.telNumber = Console.ReadLine();

            bl.updateEmployer(emplo);

        }
        static String getEmployer()
        {
            Console.WriteLine("Enter the id of the employer you are looking for:");
            string id = Console.ReadLine();
            Employer emp = bl.getEmployer(id);
            return emp.ToString();
        }
        #endregion

        #region Contract functions.
        static void addContract()
        {
            Contract c = new Contract();
            Console.WriteLine("Enter contract details:");
            Console.WriteLine("Enter employee id:");
            c.EmployeeId = Console.ReadLine();
            Console.WriteLine("Enter employee id:");
            c.EmployerId = Console.ReadLine();
            Console.WriteLine("Did you had interview?(YES/NO)");
            string answer = Console.ReadLine();
            if (answer == "YES")
            {
                c.interview = true;
            }
            else
            {
                c.interview = false;
            }
            Console.WriteLine("Enter bruto salary:");
            c.brutoSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter start time:");
            c.beginning = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter finish time:");
            c.final = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers of hours that the employee can work:");
            c.numberOfHours = int.Parse(Console.ReadLine());
            
            bl.addContract(c);

        }
        static void deleteContract()
        {
            Console.WriteLine("Enter the contract number that you want to remove");
            long num = long.Parse(Console.ReadLine());

            bl.deleteContract(bl.getContract(num));

        }
        static void updateContract()
        {
            Contract co = new Contract();
            Console.WriteLine("Enter contract to update:");
            Console.WriteLine("Enter employee id:");
            co.EmployeeId = Console.ReadLine();
            Console.WriteLine("Enter employee id:");
            co.EmployerId = Console.ReadLine();
            Console.WriteLine("Did you had interview?(YES/NO)");
            string answer = Console.ReadLine();
            if (answer == "YES")
            {
                co.interview = true;
            }
            else
                co.interview = false;
            Console.WriteLine("Enter bruto salary:");
            co.brutoSalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter start time:");
            co.beginning = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter finish time:");
            co.final = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers of hours that the employee can work:");
            co.numberOfHours = int.Parse(Console.ReadLine());

            bl.updateContract(co);

        }
        static String getContract()
        {
            Console.WriteLine("Enter the number of the contract you are looking for:");
            long num = long.Parse(Console.ReadLine());
            Contract c = bl.getContract(num);
            return c.ToString();
        }
        #endregion

        #region getall as string functions
        static String GetAllSpecializationAsString() { return bl.GetAllSpecializationAsString(); }
        static String GetAllEmployeeAsString() { return bl.GetAllEmployeeAsString(); }
        static String GetAllEmployerAsString() { return bl.GetAllEmployerAsString(); }
        static String GetAllContractAsString() { return bl.GetAllContractAsString(); }
        //static String GetAllAcountsAsString() { return ""; }
        #endregion
    }
}
