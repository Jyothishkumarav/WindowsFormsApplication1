using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Core
{
    public static class MacVerification
    {
        // add mac adds here seperate by  ","
        private static IList<string> acceptableMac = new List<string>()
        {
            "468500A9AE8E","0016411736D9",
        };

        public static  bool  GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            IList<string> macAdds = new List<string>();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {

                //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                sMacAddress = adapter.GetPhysicalAddress().ToString();
                if (acceptableMac.IndexOf(sMacAddress) != -1)
                {
                    return true;
                }


            }

            return false;
        }
    }
}
