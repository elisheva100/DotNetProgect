using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employer
    {
        public string idOrNumber { get; set; }
        public bool company { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telNumber { get; set; }
        public string CompanyName { get; set; }
        public string city { get; set; }
        public DateTime foundation { get; set; }
        //public long SpecializationNumber { get; set; }
        public int budget { get; set; }
        public Enums.job speciality { get; set; }
        //public int counter { get; set; }//The number of the contract the employer has.
        //public bool workHome { get; set; } //If the employee can work from his house.

        public override string ToString()
        {
            string str = "";
            if (company == true)
            {
                str += "Company: " + CompanyName + "\n ";
            }
            else
            {
                str += "Name: " + firstName + " " + lastName + "\n";
            }
            str += "Telephone: " + telNumber.ToString() + "\n ";
            str += "City: " + city + "\n";
            str += "Specialization: " + speciality.ToString() + "\n";
            str += "Since: " + foundation.ToString() + "\n";
            str += "Budget: " + budget.ToString() + "\n";

            return str;
        }
    }
}
