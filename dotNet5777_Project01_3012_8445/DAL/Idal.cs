using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
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

    }
}
