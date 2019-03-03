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
        static DAL.Idal dal = factoryDal.getDal();

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
            var em = dal.GetAllEmployee();

            foreach (var item in em)
            {
                if (item.SpecializationNumber == s.number)
                {
                    throw new Exception("You can't delete the specialization.\n Because there is an employee realted to it!!!");
                }
            }


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
            gift(em);
            em.car = Enums.Cars.none;//If the employee still doesn't have a contract,He doesn't have a car.
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
            var c = dal.GetAllContract();

            foreach (var item in c)
            {
                if (item.EmployeeId == em.Id)
                {
                    throw new Exception("You can't delete the employee.\n Because there is a contract realted to it!!!");
                }
            }
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
            gift(newE);
            try
            {
                dal.updateEmployee(newE);
                foreach (var c in dal.GetAllContract())
                {
                    if (c.EmployeeId == newE.Id)
                        updateContract(c);
                }

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
            var c = dal.GetAllContract();

            foreach (var item in c)
            {
                if (item.EmployerId == emp.idOrNumber)
                {
                    throw new Exception("You can't delete the employer.\n Because there is a contract realted to it!!!");
                }
            }
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
        public String addContract(BE.Contract c)
        {

            validContract(c);
            //try
            //{
            //    dal.addContract(c);
            //}
            //catch (InvalidCastException e)
            //{
            //    throw e;
            //}
            netSalary(c);
            try
            {
                properSalary(c);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            employeeVacation(c);
            car(c);
            try
            {
                c.signed = true;
                dal.addContract(c);
                //dal.updateEmployee(getEmployee(c.EmployeeId));
            }
            catch (InvalidCastException e)
            {
                throw e;
            }

            String str = homeWorker(c);

            return str;
        }

        public void deleteContract(Contract c)
        {
            Employee em;
            List<Employee> list = new List<Employee>();

            try
            {

                foreach (var e in dal.GetAllEmployee())
                {
                    if (c.EmployeeId == e.Id)
                        list.Add(e);
                }
                if (list.Count < 2)//If the employee has only the current contract - reset all his benefits.
                {
                    em = list[0];
                    em.foodCard = false;
                    em.car = Enums.Cars.none;
                    em.vacation = 0;
                    dal.updateEmployee(em);
                }
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
            String error = "";

            if (s.speciality == 0)
            {
                error += ("Choose speciality!!!\n");
            }
            if (!Legal.isString(s.name))
            {
                error += ("the specialziation name is not legal !!!\n");
            }
            if (s.minCost <= 0)
            {
                error += ("the minimal cost is not valid !!!\n");
            }
            if (s.maxCost < s.minCost)
            {
                error += ("the maximal cost is not valid !!!\n");
            }

            if (error != "")
            {
                throw new Exception(error);
            }
        }
        public void validEmployee(Employee em)
        {
            String error = "";
            if (em.d == 0)
            {
                error += ("ERROR: please choose degree!!! \n");
            }

            Specialization s = null;
            try
            {
                s = getSpecialization(em.SpecializationNumber);
            }
            catch (Exception e)
            {
                error += (e.Message + "\n");
            }

            if (Legal.legalId(em.Id) == false)
            {
                error += ("Employee's ID is not legal!!\n");
            }

            if (em.firstName == null || em.lastName == null)
            {
                error += ("Employee's name is empty!!\n");
            }

            else if (!Legal.isString(em.firstName) || !Legal.isString(em.lastName))
            {
                error += ("Employee's Name is not legal!!\n");
            }

            if (Legal.isString(em.city) == false)
            {
                error += ("Employee's address is not legal!!\n");
            }

            if (Legal.isCellPhone(em.phoneNumber) == false)
            {
                error += ("Employee phone number is not legal!!\n");
            }
            if (isAdult(em.dateBirth) == false)
            {
                error += ("Employee is too young for working!!\n");
            }
            //if (!bankAcount(em.details))
            //{
            //    error += ("Employee's Bank Acount details are incorrect!!\n");
            //}
            if (em.experience < 0)
            {
                error += ("experience value is not valid!!!\n");
            }
            if (em.hoursPerMonth < 1)
            {
                error += ("Number of hours is not valid!!!\n");
            }
            if (s == null)
            {
                error += ("The employee specialization does'nt exist!!!\n");
            }

            if (error != "")
            {
                throw new Exception(error);
            }

        }
        public void validEmployer(Employer emp)
        {
            String error = "";

            if (Legal.legalId(emp.idOrNumber) == false)
            {
                error += ("Employer's ID is not legal!!\n");
            }

            if (emp.company == true)
            {
                if (!Legal.isString(emp.CompanyName))
                {
                    error += "The company name is not legal!!!\n";
                }
            }
            else
            {
                if (emp.firstName == null || emp.lastName == null)
                {
                    error += ("Employer's name is empty!!\n");
                }

                else if (!Legal.isString(emp.firstName) || !Legal.isString(emp.lastName))
                {
                    error += ("Employer's Name is not legal!!\n");
                }
            }
            if (Legal.isString(emp.city) == false)
            {
                error += ("The address is not legal!!\n");
            }

            if (Legal.isTelPhone(emp.telNumber) == false)
            {
                error += ("Employer's telephone number is not legal\n");
            }

            if (seniority(emp) == false)
            {
                error += ("You can't have a contract because your company exists less than a year!!\n");
            }

            if (emp.budget < 0 || (0 < emp.budget && emp.budget < 1))
            {
                error += ("Budget value is not valid !!!\n");
            }

            if (error != "")
            {
                throw new Exception(error);
            }

        }
        public void validContract(Contract c)
        {
            Employee em = null;
            Employer emp = null;
            Specialization s = null;
            String error = "";
            try
            {
                em = dal.getEmployee(c.EmployeeId);
            }
            catch (Exception e)
            {
                error += (e.Message + "\n");
            }
            try
            {
                emp = dal.getEmployer(c.EmployerId);
            }
            catch (Exception e)
            {
                error += (e.Message + "\n");
            }
            try
            {
                s = dal.getSpecialization(em.SpecializationNumber);
            }
            catch (Exception e)
            {
                error += (e.Message + "\n");
            }

            if (PossibilityContract(em, emp) == false)
            {
                error += ("Contract can't be created because employer and/or employee do'nt exist!!!\n");
            }

            if (seniority(emp) == false)
            {
                error += ("employer doesn't have enough seniority!\n");
            }
            if (c.final <= c.beginning)
            {
                error += ("Final date is earlier the begginig date\n");
            }
            if (em.hoursPerMonth < c.numberOfHours)
            {
                error += "Employee's number of hours is to little!\n";
            }



            if (c.numberOfHours < 1)
            {
                error += ("The number of hours is not valid!!!\n");
            }

            try
            {
                ContractSigned(c);
            }
            catch (Exception e)
            {
                error += (e.Message + "\n");
            }

            if (error != "")
            {
                throw new Exception(error);
            }
        }
        #endregion

        #region grouping functions
        public IEnumerable<IGrouping<Enums.job, Contract>> ContractsBySpecializations(bool order = false)
        {
            if (order == false)
                return from c in GetAllContract()
                       group c by dal.getSpecialization((dal.getEmployee(c.EmployeeId).SpecializationNumber)).speciality into g
                       select g;

            return from c in GetAllContract()
                   orderby dal.getSpecialization((dal.getEmployee(c.EmployeeId).SpecializationNumber)).speciality
                   group c by dal.getSpecialization((dal.getEmployee(c.EmployeeId).SpecializationNumber)).speciality into g
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
        public IEnumerable<IGrouping<int, yearProfit>> ContractsByYearProfit(bool order = false)
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
        public IEnumerable<IGrouping<Enums.Cars, Employee>> EmployeesByCars(bool order = false)
        {
            if (order == false)
                return from em in GetAllEmployee()
                       group em by em.car into g
                       select g;
            return from em in dal.GetAllEmployee()
                   orderby em.car
                   group em by em.car into g
                   select g;

        }
        #endregion


        public bool isAdult(DateTime employeeBirth)
        {
            if (DateTime.Now.Year - employeeBirth.Year <= 18)
            {
                return false;
            }
            return true;
        }


        public bool bankAcount(BankAccount b)
        {
            List<BankAccount> banks = dal.GetAllAcounts();
            if (banks.Contains(b))//if the bank contained in the list of all the banks.
            {
                return true;
            }
            return false;

        }

        public bool PossibilityContract(Employee e, Employer em)
        {
            if (dal.getEmployee(e.Id) != null && dal.getEmployer(em.idOrNumber) != null)
            {
                return true;
            }
            return false;
        }

        public bool seniority(Employer em)
        {
            if (DateTime.Now.Year - em.foundation.Year >= 1)
            {
                return true;
            }
            return false;
        }

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

        public List<Contract> condition(Func<Contract, bool> c)
        {
            List<Contract> contract = dal.GetAllContract();
            IEnumerable<Contract> cont = contract.Where(c);
            return (List<Contract>)cont;

        }

        public int NumberOfCondition(Func<Contract, bool> c)
        {
            int num;
            List<Contract> contract = dal.GetAllContract();
            IEnumerable<Contract> cont = contract.Where(c);
            num = cont.Count();
            return num;

        }


        public string gift(Employee em)
        {
            string str = "";

            if (em.dateBirth.Day == DateTime.Now.Day && em.dateBirth.Month == DateTime.Now.Month)
            {
                em.prize = bonus;//updates the employee prize.
                str += (em.firstName + " " + em.lastName + " HAPPY BIRTHDAY!!!\n");

            }
            else
            {
                em.prize = 0;
            }
            return str;
        }

        public void car(Contract c)
        {
            Employee em = getEmployee(c.EmployeeId);
            Employer emp = getEmployer(c.EmployerId);
            if (em.city == emp.city || em.d == Enums.degree.diploma || em.d == Enums.degree.student && em.car == Enums.Cars.none)
            {
                em.car = Enums.Cars.none;
            }
            else
            {
                if (c.numberOfHours < 100 && em.car <= Enums.Cars.citroen)
                {
                    em.car = Enums.Cars.citroen;

                }
                else if (c.numberOfHours >= 100 && c.numberOfHours <= 120 && em.car <= Enums.Cars.masda)
                {
                    em.car = Enums.Cars.masda;
                }

                else if (c.numberOfHours > 120)
                {
                    em.car = Enums.Cars.mercedes;
                }
                dal.updateEmployee(em);

            }

        }

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
                em.car = Enums.Cars.none;
                str += "Because the employee is home worker, he doesn't have benefits!\n";
            }
            else
            {
                em.foodCard = true;
                dal.updateEmployee(em);
                if (em.car != Enums.Cars.none)
                {
                    str += "The employee deserve for car " + em.car.ToString() + "\n";
                }
                str += "The employee desereve a meal every day\n";
                str += "The employee deserve " + em.vacation.ToString() + " days of vacation in a year\n";
            }
            dal.updateEmployee(em);
            return str;
        }

        public void employeeVacation(Contract c)
        {
            int vacation;
            Employee em = dal.getEmployee(c.EmployeeId);


            if (em.Id != c.EmployeeId)
            {
                throw new Exception("There is no such contract");
            }
            else
            {
                vacation = (int)(c.numberOfHours / vacationParamter);//The hours of the worker / 5 
                if (em.vacation < vacation) //If the employee has another contract, he gets the maximum days.
                {
                    em.vacation = vacation;
                    dal.updateEmployee(em);
                }

            }
        }


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

        public void ContractSigned(Contract c)
        {
            Employee em = getEmployee(c.EmployeeId);
            Employer emp = getEmployer(c.EmployerId);
            Specialization s = getSpecialization(em.SpecializationNumber);
            DateTime now = DateTime.Now;

            if (now.Year - emp.foundation.Year < 1)
            {
                //c.signed = false;
                throw new Exception("Unable to sign a contract with a new company discovered less than a year!!");
            }
            //if the employee's specialization different than the employer specialization contract can't be signed.
            else if (emp.speciality != s.speciality)
            {
                // c.signed = false;
                throw new Exception("Unable to sign a contract with different specialization of employee and employer!!");
            }


        }


        public void properSalary(Contract c)
        {
            Employee em = dal.getEmployee(c.EmployeeId);
            Specialization s = dal.getSpecialization(em.SpecializationNumber);
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
                s.maxCost += (int)((emp.budget * discount) / c.numberOfHours);
                c.netoSalary += (int)((emp.budget * discount) / c.numberOfHours) * commission;
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
