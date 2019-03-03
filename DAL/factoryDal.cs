using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class factoryDal
    {
        private static DAL.Idal instance = null;
         public static Idal getDal()
        {
            if (instance == null)
            {
                //instance = new Dal_imp();
                instance = new Dal_XML_imp();
            }
            return instance;
        }
    }

}
