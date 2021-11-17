using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika.Classes
{
    public abstract class User
    {
        public int Id { get; }
        public string Username { get; private set; }
        private string _password;

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            _password = password;
        }
        public void ChangeUserName(string username)
        {
            Username = username;
        }
        public void ChangePassword(string password)
        {
            _password = password;
        }
        public bool CheckUsername(string username)
        {
            return Username == username;
        }
        public bool TryLogIn(string username, string password)
        {
            return Username == username && _password == password;
        }
    }
}
