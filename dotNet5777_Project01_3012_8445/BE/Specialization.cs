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
        public Enums.job name { get; set; }//name of the speciality
        public double minCost { get; set; }//min cost per hours for this speciality
        public double maxCost { get; set; }//max cost per hours for this speciality
        public int minHours { get; set; }//min hours require for this speciality
        public Enums.demand d { get; set; }//How is the Specialization required.

        public override string ToString()
        {
            string str = "Specialization: " + "Number: " + number + " Name: " + name.ToString() + ", ";
            str += "Minimal Cost: " + minCost.ToString() + ", ";
            str += "Maximal Cost: " + maxCost.ToString() + ", ";
            str += "Minimal Hours: " + minHours.ToString();
            return str;

        }
    };


}

