using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class EfillingDetails
    {

        public UserLogin user { get; set; }
        public string loginInfo { get; set; }
        public string efillingStatus { get; set; }
        public string initiatedList { get; set; }

        public EfillingDetails(UserLogin user, string loginInfo, string efillingStatus, string initiatedList = "")
        {
            this.user = user;
            this.loginInfo = loginInfo;
            this.efillingStatus = efillingStatus;
            this.initiatedList = initiatedList;
        }
    }
  }
