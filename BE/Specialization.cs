using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BE
{

    public class Specialization
    {
        public static long SpecializationNumber = 10000000;
        public long number { get; set; }
        public string name { get; set; }
        public Enums.job speciality { get; set; }//name of the speciality
        public double minCost { get; set; }//min cost per hours for this speciality
        public double maxCost { get; set; }//max cost per hours for this speciality
        public int minHours { get; set; }//min hours require for this speciality
       // public Enums.demand d { get; set; }//How is the Specialization required.

        public override string ToString()
        {
            string str = "Specialization: " + "Number: " + number + "\n Name: " + name + "\n";
            str += "Minimal Cost: " + minCost.ToString() + "\n ";
            str += "Maximal Cost: " + maxCost.ToString() + "\n ";
            str += "Minimal Hours: " + minHours.ToString() + "\n";
            return str;

        }
    };


}

