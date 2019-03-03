using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        public int BankNum { get; set; }
        public string BankName { get; set; }
        public int BankBranch { get; set; }
        public string BankAdress { get; set; }
        //public string BranchCity { get; set; }
        //public int AcountNumber { get; set; }

        public BankAccount() { }
        
        public BankAccount(int num, string name, int branch,/* string adress,*/ string city/*, int number*/)
        {
            BankNum = num;
            BankName = name;
            BankBranch = branch;
            BankAdress = city;
            //BranchCity = city;
            //AcountNumber = num;

        }
        public override string ToString()
        {
            string str = "";
            str += "Bank number: " + BankNum.ToString() + ", ";
            str += "Bank name: " + BankName + "\n";
            str += "Brunch number: " + BankBranch.ToString() + ", ";
            str += "Adress: " + BankAdress+ "\n";
            return str;

        }

    }
}
