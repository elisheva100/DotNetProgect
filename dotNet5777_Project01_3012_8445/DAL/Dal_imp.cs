using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{

    class Dal_imp : Idal
    {

        #region Specialization functions.
        public void addSpecialization(Specialization s)
        {
            if (s == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }

            s.number = Specialization.SpecializationNumber++;
            DataSources.specializationList.Add(s);
        }

        public void deleteSpecialization(BE.Specialization s)
        {
            if (getSpecialization(s.number) == null)
            {
                throw new Exception("ERROR :this specialization doesn't exist");
            }
            else
            {

                DataSources.specializationList.Remove(s);
            }
            return;
            
        }

        public void updateSpecialization(Specialization newJob)
        {
            Specialization s = getSpecialization(newJob.number);
            if (s == null)
            {
                throw new Exception("Specialization doesn't exist");
            }

            DataSources.specializationList.Remove(s);
            DataSources.specializationList.Add(newJob);
        }

        public Specialization getSpecialization(long num)
        {
            Specialization s = DataSources.specializationList.FirstOrDefault(x => x.number == num);
            if(s == null)
            {
                throw new Exception("This specialization doesn't exist");
            }
            return s;
        }
        #endregion

        #region Employee functions.
        public void addEmployee(Employee e)
        {
            if (e == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }

            try
            {
                getEmployee(e.Id);
            }
            catch
            {
                DataSources.employeeList.Add(e);
                return;
            }
            
            throw new Exception("ERROR :this employer number already exist");
        }

        public void deleteEmployee(BE.Employee e)
        {
            if (getEmployee(e.Id) == null)
            {
                throw new Exception("ERROR :this employee doesn't exist");
            }
            else
            {
                DataSources.employeeList.Remove(e);
            }
            return;
        }

        public void updateEmployee(Employee newE)
        {
            if (newE == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }

            Employee e = getEmployee(newE.Id);
            if (e == null)
            {
                throw new Exception("Employee doesn't exist");
            }
            else
            {
                DataSources.employeeList.Remove(e);
                DataSources.employeeList.Add(newE);
            }


        }

        public Employee getEmployee(string id)
        {
            Employee e = DataSources.employeeList.FirstOrDefault(x => x.Id == id);
            if (e == null)
            {
                throw new Exception("This employee does'nt exist");
            }
            return e;
        }
        #endregion

        #region Employer functions.
        public void addEmployer(Employer em)
        {
            if (em == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            try
            {
                getEmployer(em.idOrNumber);
            }
            catch
            {
                DataSources.employerList.Add(em);
                return;
            }

            throw new Exception("ERROR :this employee number already exist");
        }

        public void deleteEmployer(BE.Employer em)
        {
            if (getEmployer(em.idOrNumber) == null)
            {
                throw new Exception("ERROR :this employer doesn't exist");
            }
            else
            {
                DataSources.employerList.Remove(em);
            }

        }

        public void updateEmployer(Employer newEm)
        {
            if (newEm == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }

            Employer emp = getEmployer(newEm.idOrNumber);
            if (emp == null)
            {
                throw new Exception("Employer doesn't exist");
            }
            else
            {
                DataSources.employerList.Remove(emp);
                DataSources.employerList.Add(newEm);
            }
        }

        public Employer getEmployer(string num)
        {
            Employer em = DataSources.employerList.FirstOrDefault(x => x.idOrNumber == num);
            if (em == null)
            {
                throw new Exception("This employer does'nt exist");
            }
            return em;
        }
        #endregion

        #region Contract functions.
        public void addContract(BE.Contract c)
        {
            if (c == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            try
            {
                getContract(c.number);
            }
            catch
            {
                c.number = Contract.contractNumber++;
                DataSources.contractList.Add(c);
                return;
            }

            throw new Exception("ERROR :this contract number already exist");

        }

        public void deleteContract(BE.Contract c)
        {

            if (getContract(c.number) == null)
            {
                throw new Exception("ERROR :this contract doesn't exist");

            }
            else
            {
                DataSources.contractList.Remove(c);
            }

        }

        public void updateContract(BE.Contract newC)
        {

            if (newC == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            Contract c = getContract(newC.number);
            if (c == null)
            {
                throw new Exception("Contract doesn't exist!!");
            }
            else
            {
                DataSources.contractList.Remove(c);
                DataSources.contractList.Add(newC);
            }
        }

        public Contract getContract(long num)
        {
            Contract c = DataSources.contractList.FirstOrDefault(x => x.number == num);
            if (c == null)
            {
                throw new Exception("This contract does'nt exist");
            }
            return c;
        }
        #endregion


        #region GetAll functions

        public List<Specialization> GetAllSpecialization()
        {
            return DataSources.specializationList;
        }

        public List<Employee> GetAllEmployee()
        {
            return DataSources.employeeList;
        }

        public List<Employer> GetAllEmployer()
        {
            return DataSources.employerList;
        }

        public List<Contract> GetAllContract()
        {
            return DataSources.contractList;
        }
        

        public List<BankAccount> GetAllAcounts()
        {
            List<BankAccount> lst = new List<BankAccount>();
            BankAccount b1 = new BankAccount(1, "Leumi", 100, "11 Jaffa street", "Jerusalem", 1000);
            BankAccount b2 = new BankAccount(2, "Diskont", 200, "22 Alenby street", "Tel aviv", 2000);
            BankAccount b3 = new BankAccount(3, "Mizrachi", 300, "33 Rakefet street", "Ashkelon", 3000);
            BankAccount b4 = new BankAccount(1, "Pagy", 400, "44 Shaul street", "Jerusalem", 4000);
            BankAccount b5 = new BankAccount(1, "Yahav", 100, "55 Carmel street", "Haifa", 5000);
            lst.Add(b1);
            lst.Add(b2);
            lst.Add(b3);
            lst.Add(b4);
            lst.Add(b5);

            return lst;

        }
        #endregion
    }
}


