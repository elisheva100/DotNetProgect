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
        // public bool army { get; set; }
        public BankAccount details { get; set; }
        public int experience { get; set; }//According to number of years.
        public Enums.degree d { get; set; }
        // public Enums.job employeeSpecialization { get; set; }
        public int hoursPerMonth { get; set; }//How many hours the employee can work.
        public bool foodCard { get; set; }//If the employee deserve a free meal.
        public bool homeWorker { get; set; }//If the employee can work from his house
        public int prize { get; set; }//The employee gets prize on his birthday.
        public Enums.Cars car { get; set; }
        public int vacation { get; set; }//According to the number of hours of the contract.
        public int AcountNumber { get; set; }
        public override string ToString()
        {
            string str = "Employee's id: " + Id.ToString() + "\n";
            str += "employee name: " + firstName + " " + lastName + "\n";
            str += "Date of birth: " + dateBirth.ToShortDateString() + "\n";
            str += "Phone number: " + phoneNumber.ToString() + "\n";
            str += "City: " + city.ToString() + "\n";
            str += "Degree: " + d.ToString() + "\n";
            str += "Exprience: " + experience.ToString() + "\n";
            //str += "Car: " + car.ToString() + "\n";
           // str += "deserve for " + vacation.ToString() + " days of vacation in a year\n";

            return str;
        }

    }

}
