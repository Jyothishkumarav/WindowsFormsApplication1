using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1.Model
{
    public class UserLogin
    {
        public UserLogin(string userName, string password)
        {
            this.userName = userName;
            passWord = password;
        }

        public string userName { get; set; }
        public string passWord { get; set; }
    }
}
