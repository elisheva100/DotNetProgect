using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct BankAccount
    {
        private int BankNum;
        private string BankName;
        private int BankBranch;
        private string BankAdress;
        private string BranchCity;
        private int CountNumber;

        public BankAccount(int num,string name,int branch,string adress,string city,int number)
        {
            BankNum = num;
            BankName = name;
            BankBranch = branch;
            BankAdress = adress;
            BranchCity = city;
            CountNumber = num;

        }

    }
}
