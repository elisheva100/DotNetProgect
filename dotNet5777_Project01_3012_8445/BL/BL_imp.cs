using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{

    class BL_imp : IBL
    {
        static int vacationParamter = 5;//Parameter for calculateing the number of day's vacation.
        static int bonus = 300;//A bonus for the birthday
        static double commission = 0.1; //10% of commision
        static double discount = 5;//0.5% discount for every contract the employee/employer has.
        DAL.Idal dal;
        public BL_imp()
        {
            DAL.factoryDal factory = new DAL.factoryDal();
            dal = factory.getDal();
        }


        #region Specialization functions
        public void addSpecialization(Specialization s)
        {
            validSpecialization(s);
            try
            {
                dal.addSpecialization(s);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void deleteSpecialization(Specialization s)
        {
            try
            {
                dal.deleteSpecialization(s);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void updateSpecialization(Specialization newJob)
        {
            validSpecialization(newJob);
            try
            {

                dal.updateSpecialization(newJob);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public Specialization getSpecialization(long num)
        {
            return dal.getSpecialization(num);
        }
        #endregion

        #region Employee functions
        public void addEmployee(Employee em)
        {
            gift();
            validEmployee(em);

            try
            {
                dal.addEmployee(em);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void deleteEmployee(Employee em)
        {
            try
            {
                dal.deleteEmployee(em);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void updateEmployee(Employee newE)
        {
            validEmployee(newE);
            gift();
            try
            {
                dal.updateEmployee(newE);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public Employee getEmployee(string id)
        {
            return dal.getEmployee(id);
        }
        #endregion

        #region Employer function
        public void addEmployer(Employer emp)
        {
            validEmployer(emp);
            try
            {
                dal.addEmployer(emp);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void deleteEmployer(Employer emp)
        {

            try
            {
                dal.deleteEmployer(emp);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void updateEmployer(Employer newEm)
        {
            validEmployer(newEm);
            try
            {
                dal.updateEmployer(newEm);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }


        }

        public Employer getEmployer(string num)
        {
            return dal.getEmployer(num);
        }
        #endregion

        #region Contract functions
        public void addContract(BE.Contract c)
        {
            netSalary(c);
            employeeVacation(c);
            car(c);
            validContract(c);
            try
            {
                dal.addContract(c);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void deleteContract(Contract c)
        {
            try
            {
                dal.deleteContract(c);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public void updateContract(Contract newC)
        {
            netSalary(newC);
            car(newC);

            validContract(newC);
            try
            {
                dal.updateContract(newC);
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        }

        public Contract getContract(long num)
        {
            return dal.getContract(num);
        }
        #endregion

        #region GetAll functions
        public List<Specialization> GetAllSpecialization()
        {
            return dal.GetAllSpecialization();
        }

        public List<Employee> GetAllEmployee()
        {
            return dal.GetAllEmployee();
        }

        public List<Employer> GetAllEmployer()
        {
            return dal.GetAllEmployer();
        }

        public List<Contract> GetAllContract()
        {
            return dal.GetAllContract();
        }

        public List<BankAccount> GetAllAcounts()
        {
            return dal.GetAllAcounts();
        }
        #endregion

        #region getall as string functions
        public string GetAllSpecializationAsString()
        {
            string str = "";
            List<Specialization> specialization = GetAllSpecialization();
            foreach (var item in specialization)
            {
                str += item.ToString() + "\n";
            }
            return str;
        }
        public string GetAllEmployeeAsString()
        {
            string str = "";
            List<Employee> employees = GetAllEmployee();
            foreach (var item in employees)
            {
                str += item.ToString() + "\n";
            }
            return str;
        }
        public string GetAllEmployerAsString()
        {
            string str = "";
            List<Employer> employers = GetAllEmployer();
            foreach (var item in employers)
            {
                str += item.ToString() + "\n";
            }
            return str;
        }
        public string GetAllContractAsString()
        {
            string str = "";
            List<Contract> contracts = GetAllContract();
            foreach (var item in contracts)
            {
                str += item.ToString() + "\n";
            }
            return str;
        }

        #endregion

        #region valid functions
        public void validSpecialization(Specialization s)
        {
            if (s.minCost <= 0)
            {
                throw new Exception("the minimal cost is not valid !!!");
            }
            if (s.maxCost < s.minCost)
            {
                throw new Exception("the maximal cost is not valid !!!");
            }

        }
        public void validEmployee(Employee em)
        {
            if (Legal.legalId(em.Id) == false)
            {
                throw new Exception("Employee's ID is not legal!!");
            }

            if (em.firstName.Length < 1 && em.lastName.Length < 1)
            {
                throw new Exception("Employee's name is not legal!!");
            }
            if (Legal.isString(em.city) == false)
            {
                throw new Exception("Employee's address is not legal!!");
            }

            if (Legal.isCellPhone(em.phoneNumber) == false)
            {
                throw new Exception("Employee phone number is not legal!!");
            }
            if (isAdult(em.dateBirth) == false)
            {
                throw new Exception("Employee is too young for working!!");
            }
            if (!bankAcount(em.details))
            {
                throw new Exception("Employee's Bank Acount details are incorrect!!");
            }
            if (em.experience < 1)
            {
                throw new Exception("experience value is not valid!!!");
            }
            else if (em.hoursPerMonth < 1)
            {
                throw new Exception("Number of hours is not valid!!!");
            }

        }
        public void validEmployer(Employer emp)
        {
            if (Legal.legalId(emp.idOrNumber) == false)
            {
                throw new Exception("Employer's ID is not legal!!");
            }

            if (Legal.isString(emp.city) == false)
            {
                throw new Exception("The address is not legal!!");
            }

            if (Legal.isTelPhone(emp.telNumber) == false)
            {
                throw new Exception("Employer's telephone number is not legal");
            }

            if (seniority(emp) == false)
            {
                throw new Exception("You can't have a contract because your company exists less than a year!!");
            }

            if (emp.budget < 0 || (0 < emp.budget && emp.budget < 1))
            {
                throw new Exception("Budget value is not valid !!!");
            }

        }
        public void validContract(Contract c)
        {
            Employee em = dal.getEmployee(c.EmployeeId);
            Employer emp = dal.getEmployer(c.EmployerId);
            Specialization s = dal.getSpecialization(c.SpecializationNumber);
            if (PossibilityContract(em, emp) == false)
            {
                throw new Exception("Contract can't be created because employer and/or employee do'nt exist!!!");
            }

            if (seniority(emp) == false)
            {
                throw new Exception("employer doesn't have enough seniority!");
            }
            if (c.final <= c.beginning)
            {
                throw new Exception("Final date is earlier the begginig date");
            }

            properSalary(c);

            if (c.numberOfHours < 1)
            {
                throw new Exception("The number of hours is not valid!!!");
            }

            ContractSigned(c);

        }
        #endregion

        #region grouping functions
        public IEnumerable<IGrouping<Enums.job, Contract>> ContractsBySpecializations(bool order = false)
        {
            if (order == false)
                return from c in GetAllContract()
                       group c by dal.getSpecialization(c.SpecializationNumber).name into g
                       select g;
            return from c in GetAllContract()
                   orderby dal.getSpecialization( c.SpecializationNumber).name
                   group c by dal.getSpecialization(c.SpecializationNumber).name into g
                   select g;

        }
        public IEnumerable<IGrouping<string, Contract>> ContractsByEmployeeCity(bool order = false)
        {
            if (order == false)
                return from c in GetAllContract()
                       group c by getEmployee(c.EmployeeId).city into g
                       select g;
            else
                return from c in GetAllContract()
                       orderby getEmployee(c.EmployeeId).city
                       group c by getEmployee(c.EmployeeId).city into g
                       select g;
        }
        public IEnumerable<IGrouping<string, Contract>> ContractsByEmployerCity(bool order = false)
        {
            if (order == false)
                return from c in GetAllContract()
                       group c by getEmployer(c.EmployerId).city into g
                       select g;
            else
                return from c in GetAllContract()
                       orderby getEmployer(c.EmployerId).city
                       group c by getEmployer(c.EmployerId).city into g
                       select g;
        }
        public IEnumerable<IGrouping<int, yearProfit>> ContractsByMonthProfit(bool order = false)
        {
            // gets all the years and their profits
            var years =
                from x in GetAllYears()
                from y in GetAllContract()
                where IsYearInContract(y, x)
                select new yearProfit { year = x, profit = (y.brutoSalary - y.netoSalary) /** y.numberOfHours **/* CountMonthInYearInContract(y, x) };

            List<yearProfit> profits = new List<yearProfit>();

            // finds the profit sum for each year 
            foreach (var item in years)
            {
                if (!profits.Exists(yProf => yProf.year == item.year))
                    profits.Add(item);
                else
                {
                    yearProfit x = profits.Find(yProf => yProf.year == item.year);
                    int index = profits.FindIndex(yProf => yProf.year == item.year);
                    profits[index] = new yearProfit { year = x.year, profit = x.profit + item.profit };
                }
            }

            if (order == true)
                return from Y in profits.AsEnumerable()
                       orderby Y.year
                       group Y by Y.year into g
                       select g;
            else
                return from Y in profits.AsEnumerable()
                       group Y by Y.year into g
                       select g;
        }
        #endregion

        /// <summary>
        /// This function checks if the employee is at least 18 years old.
        /// </summary>
        /// <param name="employeeBirth"></param>
        /// <returns></returns>
        public bool isAdult(DateTime employeeBirth)
        {
            if (DateTime.Now.Year - employeeBirth.Year <= 18)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This function checks if the employee's bank acounts details are correct.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool bankAcount(BankAccount b)
        {
            List<BankAccount> banks = dal.GetAllAcounts();
            if (banks.Contains(b))//if the bank contained in the list of all the banks.
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// This function checks if a contract can be created.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="em"></param>
        /// <returns></returns>
        public bool PossibilityContract(Employee e, Employer em)
        {
            if (dal.getEmployee(e.Id) != null && dal.getEmployer(em.idOrNumber) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This function checks if the employer exist at least a year.
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public bool seniority(Employer em)
        {
            if (DateTime.Now.Year - em.foundation.Year >= 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This function calculates the neto salary.
        /// </summary>
        /// <param name="c"></param>
        public void netSalary(Contract c)
        {
            int numContractEmployee = 0;
            int numContractEmployer = 0;
            Employee em = dal.getEmployee(c.EmployeeId);//The employee according to the contract for birthday bonus;
            Employer emp = dal.getEmployer(c.EmployerId);//The employre according to the contract for budget;
            IEnumerable<Contract> tmpContractList1 = dal.GetAllContract().Where(x => x.EmployeeId == c.EmployeeId);//employee
            IEnumerable<Contract> tmpContractList2 = dal.GetAllContract().Where(x => x.EmployerId == c.EmployerId);//employer

            numContractEmployee = tmpContractList1.Count();//The amount of the deals the employee has.
            numContractEmployer = tmpContractList2.Count();//The amount of the deals the employer has.

            //Calculates the neto salary according to the commision,number of contract,exepirance,budget and birthday bonus.
            c.netoSalary = c.brutoSalary * (1 - commission) + ((numContractEmployee + numContractEmployer/* + em.experience + emp.budget*/) * discount) /*+ em.prize*/;
            //dal.updateContract(c);
        }



        /// <summary>
        /// This function checks if all the contracts fulfill a condition.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Contract> condition(Func<Contract, bool> c)
        {
            List<Contract> contract = dal.GetAllContract();
            IEnumerable<Contract> cont = contract.Where(c);
            return (List<Contract>)cont;

        }

        /// <summary>
        /// This function returns the amount of the contracts that fulfill a condition.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int NumberOfCondition(Func<Contract, bool> c)
        {
            int num;
            List<Contract> contract = dal.GetAllContract();
            IEnumerable<Contract> cont = contract.Where(c);
            num = cont.Count();
            return num;

        }

        /// <summary>
        /// This function checks if the employee has a birthday.
        /// </summary>
        public string gift()
        {
            string str = "";

            List<Employee> eList = dal.GetAllEmployee();
            IEnumerable<Employee> e = eList.Where(x => x.dateBirth.Day == DateTime.Now.Day && x.dateBirth.Month == DateTime.Now.Month && x.dateBirth.Year == DateTime.Now.Year);
            foreach (Employee item in e)
            {
                item.prize = bonus;//updates the employeeprize.
                str += (item.firstName + " " + item.lastName + " HAPPY BIRTHDAY!!!\n");

            }
            return str;
        }

        /// <summary>
        /// This function returns the car the employee deserves.
        /// </summary>
        /// <param name="em"></param>
        /// <param name="emp"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string car(Contract c)
        {
            Employee em = getEmployee(c.EmployeeId);
            Employer emp = getEmployer(c.EmployerId);
            if (em.city == emp.city || em.d == Enums.degree.diploma || em.d == Enums.degree.student)
            {
                c.car = Enums.Cars.none;
            }
            else
            {
                if (c.numberOfHours < 100)
                {
                    c.car = Enums.Cars.citroen;
                }
                else if (c.numberOfHours >= 100 && c.numberOfHours <= 120)
                {
                    c.car = Enums.Cars.masda;
                }

                else if (c.numberOfHours > 120)
                {
                    c.car = Enums.Cars.mercedes;
                }

            }

            return c.car.ToString();
        }

        /// <summary>
        /// This function returns if the employee is a home worker.
        /// </summary>
        /// <param name="em"></param>
        /// <param name="emp"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string homeWorker(Contract c)
        {
            Employee em = getEmployee(c.EmployeeId);
            Employer emp = getEmployer(c.EmployerId);
            if (PossibilityContract(em, emp) == false)
            {
                throw new Exception("there is no employee/employer matching to this contract!!");
            }
            string str = "";
            if (em.homeWorker)
            {
                em.foodCard = false;
                c.car = Enums.Cars.none;
                str += "Because you are home worker, you don't have benefits!\n";
            }
            else
            {
                em.foodCard = true;
                str += "You deserev a meal every day\n";
            }
            return str;
        }

        /// <summary>
        /// This function calculates the numbers of the vacation's days the employee deserve.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="c"></param>
        public void employeeVacation(Contract c)
        {
            Employee em = dal.getEmployee(c.EmployeeId);
            if (em.Id != c.EmployeeId)
            {
                throw new Exception("There is no such contract");
            }
            else
            {
                c.vacation = (int)(c.numberOfHours / vacationParamter);//The hours of the worker / 5 
            }
        }

        /// <summary>
        /// This function prints a list of all the employer that had retired.
        /// </summary>
        /// <param name="leaving"></param>
        public string allRetired(DateTime leaving)
        {
            string str = "All the retireds employees are:\n";
            Employee em = new Employee();
            List<Contract> cont = dal.GetAllContract();
            List<Employee> retireds = new List<Employee>();
            IEnumerable<Contract> co = cont.Where(x => x.final < leaving);
            foreach (var item in co)
            {
                em = dal.getEmployee(item.EmployeeId);
                retireds.Add(em);
            }

            foreach (var item in retireds)
            {
                str += item.Id + ", " + item.firstName + " " + item.lastName + "\n";
            }
            return str;

        }

        /// <summary>
        /// This function checks if a contract can be signed.
        /// </summary>
        /// <param name="c"></param>
        public void ContractSigned(Contract c)
        {
            DateTime now = DateTime.Now;
            Employer emp = dal.getEmployer(c.EmployerId);
            if (now.Year - emp.foundation.Year < 1)
            {
                throw new Exception("Unable to sign a contract with a new company discovered less than a year!!");
            }
            else
            {
                c.signed = true;
            }

        }

        /// <summary>
        /// This function returns group of all contracts acorrding to employer adress.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>


        public void properSalary(Contract c)
        {
            Employee em = dal.getEmployee(c.EmployeeId);
            Specialization s = dal.getSpecialization(c.SpecializationNumber);
            Employer emp = dal.getEmployer(c.EmployerId);

            if (c.netoSalary / c.numberOfHours < s.minCost || c.netoSalary / c.numberOfHours > s.maxCost)
            {
                throw new Exception("Salary is out of range");

            }
            if (((c.netoSalary + em.experience * discount + em.prize) / c.numberOfHours) > s.maxCost)
            {
                s.maxCost += em.experience * discount + em.prize;
                c.netoSalary += em.experience * discount + em.prize;
            }
            if ((c.netoSalary + emp.budget * discount) / c.numberOfHours > s.maxCost)
            {
                s.maxCost += emp.budget * discount;
                c.netoSalary += emp.budget * discount;
            }
        }
        public IEnumerable<int> GetAllYears() //returns a ienumerable with all the years from the first start employement year until this year
        {
            List<int> years = new List<int>();
            var contract = GetAllContract();
            int firstYear = 10000;
            int lastYear = 0;//A paramter for the end of the final dates.
            foreach (Contract c in GetAllContract())
            {
                if (c.beginning.Year < firstYear)
                    firstYear = c.beginning.Year;
            }

            foreach (Contract c in GetAllContract())
            {
                if (c.final.Year > lastYear)
                    lastYear = c.final.Year;
            }

            for (int i = firstYear; i <= lastYear; i++)
                years.Add(i);

            return years.AsEnumerable();
        }

        public bool IsYearInContract(Contract c, int year) //check if employement in contract valid for this month
        {
            if (c.beginning.Year > year)
                return false;
            if (c.final.Year < year)
                return false;
            return true;
        }

        public int CountMonthInYearInContract(Contract c, int year) //returns the amount of months in a certain year that fall during the emplyement period in a contract
        {
            if (c.beginning.Year < year && c.final.Year > year)
                return 12;//months
            if (c.beginning.Year == year && c.final.Year > year)
                return 12 - c.beginning.Month + 1;
            if (c.beginning.Year < year && c.final.Year == year)
                return c.final.Month;
            if (c.beginning.Year == year && c.final.Year == year)
                return c.final.Month - c.beginning.Month + 1;
            return 0;
        }
    }
}
