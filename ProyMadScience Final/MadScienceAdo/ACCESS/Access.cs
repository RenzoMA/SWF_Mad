using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MadScienceAdo.ACCESS
{
    class Access
    {
        public string GetCnx()
        {
            string strCnx =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\\FinalMS\\18-09\\MadScience.accdb";
            //string ip = @"\\192.168.233.2\Msj CallCenter\ms\MadScience.accdb";
            //string strCnx =
            //    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ip;

            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
    }
}
