using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApplication1.Utitity
{
   public static class ReadSettings
    {
        public static string GetuRL()
        {
            string url = ConfigurationManager.AppSettings["url"];
            return url;
        }
    }
}
