using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public static class Enums
    {
        public enum degree { diploma = 1, BA, MA, PHP, student }
        public enum job { dataBase = 1, communication, dataSecurity, information, serversideProgramming, mobileProgramming, userInterFaceDesign, softwareTesting }
        public enum demand { low = 1, nutral, high }
        public enum Cars { none = 1, citroen, masda, mercedes }//What car the employee gets
    }
}
