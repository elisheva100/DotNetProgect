using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BE
{   
    public class Employee
    {
        
        
        public long SpecializationNumber { get; set; }
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateBirth { get; set; }
        public string phoneNumber { get; set; }
        public string city { get; set; }
        public bool army { get; set; }
        public BankAccount details { get; set; }
        public int experience { get; set; }//According to number of years.
        public Enums.degree d { get; set; }
        public Enums.job employeeSpecialization { get; set; }
        public int hoursPerMonth { get; set; }//How many hours the employee can work.
        public bool foodCard { get; set; }//If the employee deserve a free meal.
        public bool homeWorker { get; set; }//If the employee can work from his house
        public int prize { get; set; }//The employee gets prize on his birthday.
        //public int counter { get; set; }//The number of the contract the employee has.

        public override string ToString()
        {
            string str = "Employee's id: " + Id.ToString() + ", ";
            str += "employee name: " + firstName + " " + lastName + ", ";
            str += "Date of birth: " + dateBirth.ToString() + ", ";
            str += "Phone number: " + phoneNumber.ToString() + ", ";
            str += "Adress: " + city.ToString() + ", ";
           // str += "Army gratuated: ";
            //if (army == true)
            //{
            //    str += "Yes\n";
            //}
            //else
            //{
            //    str += "No\n";
            //}
            //str += "Bank account details: " + details.ToString() + ", ";
            str += "Exprience: " + experience.ToString() + ", ";
            str += "Degree: " + d.ToString();
            //str += "Hours per month: " + hoursPerMonth.ToString() + "\n";
            //str += "Has a food card: ";
            //if (foodCard == true)
            //{
            //    str += "Yes\n";
            //}
            //else
            //{
            //    str += "No\n";
            //}
            //str += "Home worker: ";
            //if (homeWorker == true)
            //{
            //    str += "Yes\n";
            //}
            //else
            //{
            //    str += "No\n";
            //}
            

            return str;
        }

    }

}
