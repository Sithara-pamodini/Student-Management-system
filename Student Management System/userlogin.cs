using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    class userlogin
    {
        static string UserName;
        public static string userName
        {
            get 
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }
    }
}
