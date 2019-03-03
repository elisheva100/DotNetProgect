using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct yearProfit
    {
        public int year { get; set; }
        public double profit { get; set; }
        public override string ToString()
        {
            return profit.ToString();
        }


    }
}
