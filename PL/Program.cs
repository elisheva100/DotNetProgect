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
        static BL.IBL bl = factoryBL.getBL();
        static void Main(string[] args)
        {
            int choice = 0;

            try
            {
                // Employee
                bl.addEmployee(new Employee {Id = "208833012", firstName = "Avi", lastName = "Cohen", phoneNumber = "0536582322", experience = 8, city = "Jerusalem", SpecializationNumber = 10000000, hoursPerMonth = 120, dateBirth = new DateTime(1990, 05, 01), /*details = new BankAccount(1, "Leumi", 100, "11 Jaffa street", "Jerusalem", 1000),*/d = Enums.degree.BA });
                bl.addEmployee(new Employee { Id = "303097117", firstName = "Moshe", lastName = "Levi", phoneNumber = "0543906754", experience = 30, city = "Jerusalem", SpecializationNumber = 10000001, hoursPerMonth = 130, dateBirth = new DateTime(1967, 08, 06),/* details = new BankAccount(1, "Pagy", 400, "44 Shaul street", "Jerusalem", 4000) ,*/d = Enums.degree.diploma});

                // Employer
                bl.addEmployer(new Employer { CompanyName = "Google", company = true, city = "Jerusalem", telNumber = "5558976", foundation = new DateTime(1984, 08, 02), idOrNumber = "205374507", });
                bl.addEmployer(new Employer { firstName = "Jacobe", lastName = "Davidson", company = false, city = "Tel Aviv", telNumber = "6898976", foundation = new DateTime(1995, 08, 02), idOrNumber = "068340090" });

                // Specialization
                Specialization s1 = new Specialization { name = "communication", minCost = 100, maxCost = 150, minHours = 50, };
                Specialization s2 = new Specialization { name = "dataBase", minCost = 35, maxCost = 68, minHours = 80 };
                bl.addSpecialization(s1);
                bl.addSpecialization(s2);

                // bl.addSpecialization(new Specialization { name = Enums.job.dataSecurity, minCost = 40, maxCost = 100, minHours = 120 });
                //bl.addSpecialization(new Specialization { name = Enums.job.information, minCost = 25, maxCost = 60, minHours = 50 });
                // bl.addSpecialization(new Specialization { name = Enums.job.mobileProgramming, minCost = 70, maxCost = 120, minHours = 100 });
                // bl.addSpecialization(new Specialization { name = Enums.job.serversideProgramming, minCost = 80, maxCost = 150, minHours = 180 });
                //bl.addSpecialization(new Specialization { name = Enums.job.softwareTesting, minCost = 30, maxCost = 80, minHours = 85 });
                // bl.addSpecialization(new Specialization { name = Enums.job.userInterFaceDesign, minCost = 40, maxCost = 80, minHours = 50 });
                // Contract
                bl.addContract(new Contract { beginning = DateTime.Now, final = new DateTime(2020, 09, 03), EmployeeId = "208833012", EmployerId = "205374507", brutoSalary = 15000, numberOfHours = 120});
                bl.addContract(new Contract { beginning = DateTime.Now, final = new DateTime(2018, 06, 11), EmployeeId = "303097117", EmployerId = "068340090", brutoSalary = 10000,numberOfHours = 150});



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Group Contracts By Specializations: \n");
            var group = bl.ContractsBySpecializations(false);
            foreach (var item in group)
            {
                Console.WriteLine(item.Key);
                foreach (Contract c in item)
                {
                    Console.WriteLine(c.ToString() + "\n");
                }
            }
            Console.WriteLine("Contracts By Employer City: \n");
            var group1 = bl.ContractsByEmployerCity(false);
            foreach (var item in group1)
            {
                Console.WriteLine(item.Key);
                foreach (Contract c in item)
                {
                    Console.WriteLine(c.ToString() + "\n");
                }
            }
            Console.WriteLine("Contracts By years profit: \n");
            var group3 = bl.ContractsByYearProfit(false);
            foreach (var item in group3)
            {
                Console.WriteLine(item.Key);
                foreach (yearProfit Year in item)
                {
                    Console.WriteLine(Year.profit.ToString() + " NIS\n");
                }
            }
            Console.WriteLine("Employees By cars: \n");
            var group4 = bl.EmployeesByCars(false);
            foreach (var item in group4)
            {
                Console.WriteLine(item.Key);
                foreach (Employee em in item)
                {
                    Console.WriteLine(em.car.ToString() + "\n");
                }
            }

            String[] dataSources = { "spacialization", "employee", "employer", "contract" };
            String[] operation = { "adding", "deleting", "updating", "find", "getListOf" };

            Console.WriteLine("Welcome to our Employment agency");

            while (true)
            {
                Console.WriteLine("to exit, press 0");
                for (int i = 0, index = 1; i < dataSources.Length; i++)
                {
                    for (int j = 0; j < operation.Length; j++, ++index)
                    {
                        Console.WriteLine("for {0} {1} press {2}", operation[j], dataSources[i], index);
                    }
                    Console.WriteLine();
                }

                choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    break;
                }

                try
                {
                    switch (choice)
                    {
                        case 1: { addSpecialization(); break; }
                        case 2: { deleteSpecialization(); break; }
                        case 3: { updateSpecialization(); break; }
                        case 4: { Console.WriteLine(getSpecialization()); break; }
                        case 5: { Console.WriteLine(GetAllSpecializationAsString()); break; }
                        case 6: { addEmployee(); break; }
                        case 7: { deleteEmployee(); break; }
                        case 8: { updateEmployee(); break; }
                        case 9: { Console.WriteLine(getEmployee()); break; }
                        case 10: { Console.WriteLine(GetAllEmployeeAsString()); break; }
                        case 11: { addEmployer(); break; }
                        case 12: { deleteEmployer(); break; }
                        case 13: { updateEmployer(); break; }
                        case 14: { Console.WriteLine(getEmployer()); break; }
                        case 15: { Console.WriteLine(GetAllEmployerAsString()); break; }
                        case 16: { addContract(); break; }
                        case 17: { deleteContract(); break; }
                        case 18: { updateContract(); break; }
                        case 19: { Console.WriteLine(getContract()); break; }
                        case 20: { Console.WriteLine(GetAllContractAsString()); break; }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }




            }
        }
    }
}
