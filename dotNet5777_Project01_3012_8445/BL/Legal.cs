using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Legal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool legalId(string s)
        {
            int x;
            if (!int.TryParse(s, out x))
                return false;
            if (s.Length < 5 || s.Length > 9)
                return false;
            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;
            }
            return sum % 10 == 0;
        }
        /// <summary>
        /// This function checks if an input is a string
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool isString(string st)
        {

            foreach (var item in st)
            {
                if ( ('A' <= item && item < 'z') || item == ' ' || item == '-')
                    return true;
            }

            return false;
        }
        /// <summary>
        /// This function checks if the input is a number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool isNum(string n)
        {
            
            int num;
            if(!int.TryParse(n,out num))
            {
                return false;
            }
            return true;
        }

        public static bool isDate(string d)
        {
            DateTime date;
            if(!DateTime.TryParse(d,out date))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// This function checks if an input is a legal cellphone number.
        /// </summary>
        /// <param name="pel"></param>
        /// <returns></returns>
        public static bool isCellPhone(string pel)
        {
            if (pel.Length != 10)
            {
                return false;
            }
            foreach (var item in pel)
            {
                if (item > '9' || item < '0')
                    return false;
            }
            return true;
        }
        /// <summary>
        /// This function checks if an input is a legal telephone number.
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool isTelPhone(string tel)
        {
            if (tel.Length != 7)
            {
                return false;
            }
            foreach (var item in tel)
            {
                if (item > '9' || item < '0')
                    return false;
            }
            return true;
        }
    }
}

