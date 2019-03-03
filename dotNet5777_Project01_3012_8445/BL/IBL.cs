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
        void addContract(Contract c);
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
        IEnumerable<IGrouping<int, yearProfit>> ContractsByMonthProfit(bool order = false);
        #endregion
        bool isAdult(DateTime employeeBirth);
        bool bankAcount(BankAccount b);
        bool PossibilityContract(Employee e, Employer em);//Check if the employer and the employee are exists.
        bool seniority(Employer em);//if the company exist more than year;
        void netSalary(Contract c);
        //void brutSalary(Contract c);
        List<Contract> condition(Func<Contract, bool> c);
        int NumberOfCondition(Func<Contract, bool> c);
        
        // our functions
        string gift();//Return message if the employee has a birthday.
        string car(Contract c);//Return if the employee deserves a car.
        string homeWorker(Contract c);//Return message if the employee deserves benefits.
        void employeeVacation(Contract c);//updates if the employee deserves vacation.
        string allRetired(DateTime leaving);//prints all the employees that left before the final date.
        void ContractSigned(Contract c);
        void properSalary(Contract c); //This function checks if the neto salary is proper.
        IEnumerable<int> GetAllYears();
        bool IsYearInContract(Contract c, int year);
        int CountMonthInYearInContract(Contract c, int year);
    }
}




