using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Net;


namespace DAL
{
    public class Dal_XML_imp : Idal
    {


        static string ContractXml = @"ContractXml.xml";
        static string EmployeeXml = @"EmployeeXml.xml";
        static string EmployerXml = @"EmployerXml.xml";
        static string SpecializationXml = @"SpacializationXml.xml";
        static string BankAccountXml = @"BankAccountXml.xml";
        static XElement contracts;
        static XElement employees;
        static XElement employers;
        static XElement spacializations;
        static XElement bankAccounts;

        public Dal_XML_imp()
        {
            if (!File.Exists(ContractXml))
            {
                contracts = new XElement("Contracts");
                contracts.Save(ContractXml);
            }
            else
            {
                try
                {
                    contracts = new XElement(XElement.Load(ContractXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(EmployeeXml))
            {
                employees = new XElement("Employees");
                employees.Save(EmployeeXml);
            }
            else
            {
                try
                {
                    employees = new XElement(XElement.Load(EmployeeXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(EmployerXml))
            {
                employers = new XElement("Employers");
                employers.Save(EmployerXml);
            }
            else
            {
                try
                {
                    employers = new XElement(XElement.Load(EmployerXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(SpecializationXml))
            {
                spacializations = new XElement("Spacializations");
                spacializations.Save(SpecializationXml);
            }
            else
            {
                try
                {
                    spacializations = new XElement(XElement.Load(SpecializationXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(BankAccountXml))
            {
                WebClient wc = new WebClient();
                try
                {
                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);

                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);
                }
                finally
                {
                    wc.Dispose();
                }
            }
            else
            {
                try
                {
                    bankAccounts = new XElement(XElement.Load(BankAccountXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
        }

        #region Build XElement
        XElement BuildXelementContract(Contract c)
        {
            XElement Number = new XElement("Number", c.number);
            XElement EmployerId = new XElement("EmployerId", c.EmployerId);
            XElement EmployeeId = new XElement("EmployeeId", c.EmployeeId);
            XElement IsInterviewed = new XElement("IsInterviewed", c.interview);
            XElement IsSinged = new XElement("IsSinged", c.signed);
            XElement BrutoSalary = new XElement("BrutoSalary", c.brutoSalary);
            XElement NetoSalary = new XElement("NetoSalary", c.netoSalary);
            XElement Beginnig = new XElement("Beginnig", c.beginning);
            XElement Final = new XElement("Final", c.final);
            XElement NumberOfHours = new XElement("NumberOfHours", c.numberOfHours);
            return new XElement("Contract", Number, EmployerId, EmployeeId, IsInterviewed, IsSinged, BrutoSalary, NetoSalary, Beginnig, Final, NumberOfHours);
        }
        XElement BuildXelementEmployee(Employee e)
        {
            XElement Id = new XElement("Id", e.Id);
            XElement FirstName = new XElement("FirstName", e.firstName);
            XElement LastName = new XElement("LastName", e.lastName);
            XElement DateBirth = new XElement("DateBirth", e.dateBirth);
            XElement PhoneNumber = new XElement("PhoneNumber", e.phoneNumber);
            XElement City = new XElement("City", e.city);
            XElement Degree = new XElement("Degree", e.d);
            XElement Experience = new XElement("Experience", e.experience);
            XElement BankNumber = new XElement("BankNumber", e.details.BankNum);
            XElement BranchNumber = new XElement("BranchNumber", e.details.BankBranch);
            XElement Adress = new XElement("Adress", e.details.BankAdress);
            XElement BankName = new XElement("BankName", e.details.BankName);
            XElement BankAccount = new XElement("BankAccount", BankNumber, BankName, BranchNumber, Adress);
            XElement AccountNuber = new XElement("AccountNumber", e.AcountNumber);
            XElement Speciality = new XElement("Speciality", e.SpecializationNumber);
            XElement Car = new XElement("Car", e.car);
            XElement FoodCard = new XElement("FoodCard", e.foodCard);
            XElement HomeWorker = new XElement("HomeWorker", e.homeWorker);
            XElement Prize = new XElement("Prize", e.prize);
            XElement Vacation = new XElement("Vacation", e.vacation);
            XElement Hours = new XElement("Hours", e.hoursPerMonth);
            return new XElement("Employee", Id, FirstName, LastName, DateBirth, PhoneNumber, City, Degree, Experience, BankAccount, AccountNuber, Speciality, Car, FoodCard, HomeWorker, Prize, Vacation, Hours);
        }
        XElement BuildXelementEmployer(Employer e)
        {
            XElement Id = new XElement("Id", e.idOrNumber);
            XElement Budget = new XElement("Budget", e.budget);
            XElement Company = new XElement("Company", e.company);
            XElement FirstName = new XElement("FirstName", e.firstName);
            XElement LastName = new XElement("LastName", e.lastName);
            XElement CompanyName = new XElement("CompanyName", e.CompanyName);
            XElement TelNumber = new XElement("TelNumber", e.telNumber);
            XElement City = new XElement("City", e.city);
            XElement Speciality = new XElement("Speciality", e.speciality);
            XElement Foundation = new XElement("Foundation", e.foundation);
            return new XElement("Employer", Id, Budget, Company, FirstName, LastName, CompanyName, TelNumber, City, Speciality, Foundation);
        }
        XElement BuildXelementSpecialization(Specialization s)
        {
            XElement Number = new XElement("Number", s.number);
            XElement SpecialtyName = new XElement("SpecialtyName", s.name);
            XElement Speciality = new XElement("Speciality", s.speciality);
            XElement MinCost = new XElement("MinCost", s.minCost);
            XElement MaxCost = new XElement("MaxCost", s.maxCost);

            return new XElement("Specialization", Number, SpecialtyName, Speciality, MinCost, MaxCost);
        }
        #endregion

        #region Build Object
        Contract BuildContract(XElement xc)
        {
            Contract c = new Contract();
            c.number = Convert.ToInt32(xc.Element("Number").Value);
            c.EmployerId = (xc.Element("EmployerId").Value);
            c.EmployeeId = (xc.Element("EmployeeId").Value);
            c.interview = Convert.ToBoolean(xc.Element("IsInterviewed").Value);
            c.signed = Convert.ToBoolean(xc.Element("IsSinged").Value);
            c.brutoSalary = Convert.ToDouble(xc.Element("BrutoSalary").Value);
            c.netoSalary = Convert.ToDouble(xc.Element("NetoSalary").Value);
            c.beginning = Convert.ToDateTime(xc.Element("Beginnig").Value);
            c.final = Convert.ToDateTime(xc.Element("Final").Value);
            c.numberOfHours = Convert.ToInt32(xc.Element("NumberOfHours").Value);
            return c;
        }
        Employee BuildEmployee(XElement xe)
        {
            Employee e = new Employee();
            e.Id = (xe.Element("Id").Value);
            e.firstName = xe.Element("FirstName").Value;
            e.lastName = xe.Element("LastName").Value;
            e.dateBirth = Convert.ToDateTime(xe.Element("DateBirth").Value);
            e.phoneNumber = xe.Element("PhoneNumber").Value;
            e.city = xe.Element("City").Value;
            e.d = (Enums.degree)Enum.Parse(typeof(Enums.degree), xe.Element("Degree").Value);
            e.experience = Convert.ToInt32(xe.Element("Experience").Value);
            BankAccount t = new BankAccount();
            t.BankNum = Convert.ToInt32(xe.Element("BankAccount").Element("BankNumber").Value);
            t.BankName = xe.Element("BankAccount").Element("BankName").Value;
            t.BankBranch = Convert.ToInt32(xe.Element("BankAccount").Element("BranchNumber").Value);
            t.BankAdress = xe.Element("BankAccount").Element("Adress").Value;
            e.details = t;
            e.AcountNumber = Convert.ToInt32(xe.Element("AccountNumber").Value);
            e.SpecializationNumber = Convert.ToInt32(xe.Element("Speciality").Value);
            e.car = (Enums.Cars)Enum.Parse(typeof(Enums.Cars), xe.Element("Car").Value);
            e.foodCard = Convert.ToBoolean(xe.Element("FoodCard").Value);
            e.homeWorker = Convert.ToBoolean(xe.Element("HomeWorker").Value);
            e.prize = Convert.ToInt32(xe.Element("Prize").Value);
            e.vacation = Convert.ToInt32(xe.Element("Vacation").Value);
            e.hoursPerMonth = Convert.ToInt32(xe.Element("Hours").Value);
            return e;
        }
        Employer BuildEmployer(XElement xe)
        {
            Employer e = new Employer();
            e.idOrNumber = (xe.Element("Id").Value);
            e.budget = Convert.ToInt32(xe.Element("Budget").Value);
            e.company = Convert.ToBoolean(xe.Element("Company").Value);
            e.firstName = xe.Element("FirstName").Value;
            e.lastName = xe.Element("LastName").Value;
            e.CompanyName = (xe.Element("CompanyName").Value);
            e.telNumber = (xe.Element("TelNumber").Value);
            e.city = xe.Element("City").Value;
            e.speciality = (Enums.job)Enum.Parse(typeof(Enums.job), xe.Element("Speciality").Value);
            e.foundation = Convert.ToDateTime(xe.Element("Foundation").Value);
            return e;
        }
        BankAccount BuildBankAccount(XElement xe)
        {
            BankAccount ba = new BankAccount();
            ba.BankName = xe.Element("שם_בנק").Value;
            ba.BankNum = Convert.ToInt32(xe.Element("קוד_בנק").Value);
            ba.BankBranch = Convert.ToInt32(xe.Element("קוד_סניף").Value);
            ba.BankAdress = xe.Element("ישוב").Value;
            return ba;
        }
        Specialization BuildSpacialization(XElement xe)
        {
            Specialization s = new Specialization();
            s.number = Convert.ToInt32(xe.Element("Number").Value);
            s.name = xe.Element("SpecialtyName").Value;
            s.speciality = (Enums.job)Enum.Parse(typeof(Enums.job), xe.Element("Speciality").Value);
            s.minCost = Convert.ToDouble(xe.Element("MinCost").Value);
            s.maxCost = Convert.ToDouble(xe.Element("MaxCost").Value);
            return s;
        }
        #endregion

        #region Add Functions
        public void addContract(Contract c)
        {
            List<Contract> list = this.GetAllContract();


            foreach (var item in list)
            {
                if (item.number == c.number)

                {
                    throw new Exception("This contract allready exist !!!");
                }
            }
            if (list.Count == 0)
            {

                c.number = 10000000;

            }
            else
            {
                c.number = list[list.Count() - 1].number + 1;
            }

            contracts.Add(BuildXelementContract(c));
            contracts.Save(ContractXml);
            //DataSources.contractList.Add(c);
            //return;

        }


        //}

        public void addEmployee(Employee e)
        {
            if (e == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            foreach (var item in this.GetAllEmployee())
            {
                if (item.Id == e.Id)
                    throw new Exception("This employee allready exist !!!");
            }

            employees.Add(BuildXelementEmployee(e));
            employees.Save(EmployeeXml);
            //DataSources.employerList.Add(em);
            //return;
        }


        //}

        public void addEmployer(Employer em)
        {
            if (em == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            foreach (var item in this.GetAllEmployer())
            {
                if (item.idOrNumber == em.idOrNumber)
                    throw new Exception("This employer allready exist !!!");
            }
            employers.Add(BuildXelementEmployer(em));
            employers.Save(EmployerXml);
            //DataSources.employerList.Add(em);
            //return;
        }



        public void addSpecialization(Specialization s)
        {
            if (s == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            List<Specialization> list = this.GetAllSpecialization();


            foreach (var item in list)
            {
                if (item.number == s.number)

                {
                    throw new Exception("This Specialization allready exist !!!");
                }

            }
            if (list.Count == 0)
            {

                s.number = 10000000;

            }
            else
            {
                s.number = list[list.Count() - 1].number + 1;
            }
            //DataSources.specializationList.Add(s);

            spacializations.Add(BuildXelementSpecialization(s));
            spacializations.Save(SpecializationXml);


        }

        #endregion

        #region Get Functions
        public List<BankAccount> GetAllAcounts()
        {
            return (from v in bankAccounts.Elements()
                    select BuildBankAccount(v)).ToList();
        }

        public List<Contract> GetAllContract()
        {
            return (from v in contracts.Elements()
                    select BuildContract(v)).ToList();
        }

        public List<Employee> GetAllEmployee()
        {
            return (from v in employees.Elements()
                    select BuildEmployee(v)).ToList();
        }

        public List<Employer> GetAllEmployer()
        {
            return (from v in employers.Elements()
                    select BuildEmployer(v)).ToList();
        }

        public List<Specialization> GetAllSpecialization()
        {
            return (from v in spacializations.Elements()
                    select BuildSpacialization(v)).ToList();
        }
        #endregion

        #region Remove Functions
        public void deleteContract(Contract c)
        {
            XElement current = (from x in contracts.Elements()
                                where Convert.ToInt32(x.Element("Number").Value) == c.number
                                select x).FirstOrDefault();
            current.Remove();
            contracts.Save(ContractXml);
        }

        public void deleteEmployee(Employee e)
        {
            XElement current = (from x in employees.Elements()
                                where (x.Element("Id").Value) == e.Id
                                select x).FirstOrDefault();
            current.Remove();
            employees.Save(EmployeeXml);
        }

        public void deleteEmployer(Employer e)
        {
            XElement current = (from x in employers.Elements()
                                where (x.Element("Id").Value) == e.idOrNumber
                                select x).FirstOrDefault();
            current.Remove();
            employers.Save(EmployerXml);
        }

        public void deleteSpecialization(Specialization s)
        {
            XElement current = (from x in spacializations.Elements()
                                where Convert.ToInt32(x.Element("Number").Value) == s.number
                                select x).FirstOrDefault();
            current.Remove();
            spacializations.Save(SpecializationXml);
        }
        #endregion

        #region Update Functions
        public void updateContract(Contract c)
        {
            XElement current = (from x in contracts.Elements()
                                where x.Element("Number").Value == Convert.ToString(c.number)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current contract doesn't exist");
            current.Element("EmployerId").Value = Convert.ToString(c.EmployerId);
            current.Element("EmployeeId").Value = Convert.ToString(c.EmployeeId);
            current.Element("IsInterviewed").Value = Convert.ToString(c.interview);
            current.Element("IsSinged").Value = Convert.ToString(c.signed);
            current.Element("BrutoSalary").Value = Convert.ToString(c.brutoSalary);
            current.Element("NetoSalary").Value = Convert.ToString(c.netoSalary);
            current.Element("Beginnig").Value = Convert.ToString(c.beginning);
            current.Element("Final").Value = Convert.ToString(c.final);
            current.Element("NumberOfHours").Value = Convert.ToString(c.numberOfHours);
            contracts.Save(ContractXml);

        }

        public void updateEmployee(Employee e)
        {
            XElement current = (from x in employees.Elements()
                                where x.Element("Id").Value == Convert.ToString(e.Id)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employee doesn't exist");
            current.Element("FirstName").Value = e.firstName;
            current.Element("LastName").Value = e.lastName;
            current.Element("DateBirth").Value = Convert.ToString(e.dateBirth);
            current.Element("PhoneNumber").Value = Convert.ToString(e.phoneNumber);
            current.Element("City").Value = e.city;

            current.Element("Degree").Value = Convert.ToString(e.d);

            current.Element("Experience").Value = Convert.ToString(e.experience);
            current.Element("BankAccount").Element("BankNumber").Value = Convert.ToString(e.details.BankNum);
            current.Element("BankAccount").Element("BankName").Value = e.details.BankName;
            current.Element("BankAccount").Element("Adress").Value = e.details.BankAdress;
            current.Element("BankAccount").Element("BranchNumber").Value = Convert.ToString(e.details.BankBranch);
            current.Element("AccountNumber").Value = Convert.ToString(e.AcountNumber);
            current.Element("Speciality").Value = Convert.ToString(e.SpecializationNumber);
            current.Element("Car").Value = Convert.ToString(e.car);
            current.Element("FoodCard").Value = Convert.ToString(e.foodCard);
            current.Element("HomeWorker").Value = Convert.ToString(e.homeWorker);
            current.Element("Prize").Value = Convert.ToString(e.prize);
            current.Element("Vacation").Value = Convert.ToString(e.vacation);
            current.Element("Hours").Value = Convert.ToString(e.hoursPerMonth);
            employees.Save(EmployeeXml);
        }

        public void updateEmployer(Employer e)
        {
            XElement current = (from x in employers.Elements()
                                where x.Element("Id").Value == Convert.ToString(e.idOrNumber)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employer doesn't exist");
            current.Element("Budget").Value = Convert.ToString(e.budget);
            current.Element("Company").Value = Convert.ToString(e.company);
            current.Element("FirstName").Value = e.firstName;
            current.Element("LastName").Value = e.lastName;
            current.Element("CompanyName").Value = e.CompanyName;
            current.Element("TelNumber").Value = Convert.ToString(e.telNumber);
            current.Element("City").Value = e.city;
            current.Element("Speciality").Value = Convert.ToString(e.speciality);
            current.Element("Foundation").Value = Convert.ToString(e.foundation);
            employers.Save(EmployerXml);
        }

        public void updateSpecialization(Specialization s)
        {
            XElement current = (from x in spacializations.Elements()
                                where x.Element("Number").Value == Convert.ToString(s.number)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current specialization doesn't exist");
            current.Element("SpecialtyName").Value = (s.name);
            current.Element("Speciality").Value = Convert.ToString(s.speciality);
            current.Element("MinCost").Value = Convert.ToString(s.minCost);
            current.Element("MaxCost").Value = Convert.ToString(s.maxCost);
            spacializations.Save(SpecializationXml);
        }
        #endregion

        #region get functions
        public Employee getEmployee(string num)
        {
            List<Employee> li = this.GetAllEmployee();

            foreach (var item in li)
            {
                if (item.Id == num)
                    return item;
            }
            return null;
        }
        public Employer getEmployer(string num)
        {
            List<Employer> li = this.GetAllEmployer();

            foreach (var item in li)
            {
                if (item.idOrNumber == num)
                    return item;
            }
            return null;
        }
        public Contract getContract(long num)
        {
            List<Contract> li = this.GetAllContract();

            foreach (var item in li)
            {
                if (item.number == num)
                    return item;
            }
            return null;
        }
        public Specialization getSpecialization(long num)
        {
            List<Specialization> li = this.GetAllSpecialization();

            foreach (var item in li)
            {
                if (item.number == num)
                    return item;
            }
            return null;
        }
        #endregion

    }
}

