using ProgramosLogika.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika
{
    public class Engine
    {
        public UserDB UserDatabase = new UserDB();
        public bool UsernameExists(string username)
        {
            return UserDatabase.CheckUsernameExists(username);
        }
    }
}
