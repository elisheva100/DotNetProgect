using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {

        #region Specialization functions.
        void addSpecialization(Specialization s);
        void deleteSpecialization(Specialization s);
        void updateSpecialization(Specialization newJob);
        Specialization getSpecialization(long num);
        #endregion

        #region Employee functions.
        void addEmployee(Employee em);
        void deleteEmployee(Employee em);
        void updateEmployee(Employee newE);
        Employee getEmployee(string id);
        #endregion

        #region Employer functions.
        void addEmployer(Employer emp);
        void deleteEmployer(Employer emp);
        void updateEmployer(Employer newEm);
        Employer getEmployer(string num);
        #endregion

        #region Contract functions.
        String addContract(Contract c);
        void deleteContract(Contract c);
        void updateContract(Contract newC);
        Contract getContract(long num);
        #endregion


        #region GetAll functions
        List<Specialization> GetAllSpecialization();
        List<Employee> GetAllEmployee();
        List<Employer> GetAllEmployer();
        List<Contract> GetAllContract();
        List<BankAccount> GetAllAcounts();
        #endregion
        #region getall as string functions
        string GetAllSpecializationAsString();
        string GetAllEmployeeAsString();
        string GetAllEmployerAsString();
        string GetAllContractAsString();
        //string GetAllAcountsAsString();
        #endregion

        #region Valid functions
        void validSpecialization(Specialization s);
        void validEmployee(Employee em);
        void validEmployer(Employer emp);
        void validContract(Contract c);
        #endregion

        #region grouping functions
        IEnumerable<IGrouping<Enums.job, Contract>> ContractsBySpecializations(bool order = false);//groups contract by specialzations.
        IEnumerable<IGrouping<string, Contract>> ContractsByEmployeeCity(bool order = false); //groups contracts by cities employees live in
        IEnumerable<IGrouping<string, Contract>> ContractsByEmployerCity(bool order = false);//groups contracts by cities  companies are located in
        IEnumerable<IGrouping<int, yearProfit>> ContractsByYearProfit(bool order = false);
        IEnumerable<IGrouping<Enums.Cars, Employee>> EmployeesByCars(bool order = false);
        #endregion

        /// <summary>
        /// This function checks if the employee is at least 18 years old.
        /// </summary>
        /// <param name="employeeBirth"></param>
        /// <returns></returns>
        bool isAdult(DateTime employeeBirth);

        /// <summary>
        /// This function checks if the employee's bank acounts details are correct.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        bool bankAcount(BankAccount b);

        /// <summary>
        /// This function checks if a contract can be created.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="em"></param>
        /// <returns></returns>
        bool PossibilityContract(Employee e, Employer em);//Check if the employer and the employee are exists.

        /// <summary>
        /// This function checks if the employer exist at least a year.
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        bool seniority(Employer em);//if the company exist more than year;

        /// <summary>
        /// This function calculates the neto salary.
        /// </summary>
        /// <param name="c"></param>
        void netSalary(Contract c);

        /// <summary>
        /// This function checks if all the contracts fulfill a condition.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        List<Contract> condition(Func<Contract, bool> c);

        /// <summary>
        /// This function returns the amount of the contracts that fulfill a condition.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        int NumberOfCondition(Func<Contract, bool> c);

        // our functions
        /// <summary>
        /// This function checks if the employee has a birthday.
        /// </summary>
        string gift(Employee em);

        /// <summary>
        /// This function returns the car the employee deserves.
        /// </summary>
        /// <param name="em"></param>
        /// <param name="emp"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        void car(Contract c);

        /// <summary>
        /// This function returns if the employee is a home worker.
        /// </summary>
        /// <param name="em"></param>
        /// <param name="emp"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        string homeWorker(Contract c);
        
        /// <summary>
        /// This function calculates the numbers of the vacation's days the employee deserve.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="c"></param>
        void employeeVacation(Contract c);

        /// <summary>
        /// This function prints a list of all the employer that had retired.
        /// </summary>
        /// <param name="leaving"></param>
        string allRetired(DateTime leaving);

        /// <summary>
        /// This function checks if a contract can be signed.
        /// </summary>
        /// <param name="c"></param>
        void ContractSigned(Contract c);

        /// <summary>
        /// This function checks if a salary is in the proper range.
        /// </summary>
        /// <param name="c"></param>
        void properSalary(Contract c);
        /// <summary>
        /// This function returns all the years where a contract exist.
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> GetAllYears();
        /// <summary>
        /// This function checks if a specific year is in the contract.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        bool IsYearInContract(Contract c, int year);

        /// <summary>
        /// This function calculates the number of months in a year.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        int CountMonthInYearInContract(Contract c, int year);
    }
}




