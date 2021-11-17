using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika
{
    public static class Functions
    {
        public static int CheckRegFields(string username, string vardas,string pavarde, string password, string rePassword)
        {
            if(username!=""&&vardas!=""&&pavarde!=""&&password!=""&& rePassword != "")
            {
                if (password == rePassword)
                {
                    return 0;
                }
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
