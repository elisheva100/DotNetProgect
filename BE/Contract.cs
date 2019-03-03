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
        // public long SpecializationNumber { get; set; }
        public bool interview { get; set; }
        public bool signed { get; set; }
        public double brutoSalary { get; set; }//per month
        public double netoSalary { get; set; }
        public DateTime beginning { get; set; }
        public DateTime final { get; set; }
        public int numberOfHours { get; set; }//per month
        //public double profit { get; set; }
        //public DateTime leaving { get; set; }//If the employee left before the final date.
        //public Enums.Cars car { get; set; }
        
        public override string ToString()
        {
            string str = "Contract number: " + number.ToString() + "\n";
            str += "Employer Id: " + EmployerId.ToString() + "\n";
            str += "Employee Id " + EmployeeId.ToString() + "\n";
            str += "Interview: ";
            if (interview == true)
            {
                str += "Yes,";
            }
            else
            {
                str += "No,";
            }
            str += "\nSigned: ";
            if (signed == true)
            {
                str += "Yes,";
            }
            else
            {
                str += "No,";
            }

            str += "\nNeto salary: " + netoSalary.ToString() + "\n";
            str += "Beggining date of work: " + beginning.ToShortDateString() + "\n";
            str += "Final date of work: " + final.ToShortDateString() + "\n";
            return str;
        }

    }
}
