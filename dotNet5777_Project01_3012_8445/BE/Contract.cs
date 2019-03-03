using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{


    public class Contract
    {
        public static long contractNumber = 10000000;
        public long number { get; set; }
        public string EmployerId { get; set; }
        public string EmployeeId { get; set; }
        public long SpecializationNumber { get; set; }
        public bool interview { get; set; }
        public bool signed { get; set; }
        public double brutoSalary { get; set; }//per month
        public double netoSalary { get; set; }
        public DateTime beginning { get; set; }
        public DateTime final { get; set; }
        public int numberOfHours { get; set; }//per month
        public double profit { get; set; }
        public DateTime leaving { get; set; }//If the employee left before the final date.
        public Enums.Cars car { get; set; }
        public int vacation { get; set; }//According to the number of hours.
        public override string ToString()
        {
            string str = "Contract number: " + number.ToString() + ", ";
            //str += "Employer Id: " + EmployeeId.ToString() + ",";
            // str += "Employee Id " + EmployeeId.ToString() + ",";
            str += "Interview: ";
            if (interview == true)
            {
                str += "Yes,";
            }
            else
            {
                str += "No,";
            }
            str += "Signed: ";
            if (signed == true)
            {
                str += "Yes,";
            }
            else
            {
                str += "No,";
            }
            //str += "Bruto salary: " + brutoSalary.ToString() + "";
            str += "Neto salary: " + netoSalary.ToString() + " ";
            str += "Beggining date of work: ," + beginning.ToString() + "Final date of work: " + final.ToString() + " ";
            //str += "Number of Hours per month: " + numberOfHours.ToString() + " ";
            str += "deserve for " + vacation.ToString() + " days of vacation in a year ";
            str += "Car: " + car.ToString();
            return str;
        }

    }
}
