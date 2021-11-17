using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika.Classes
{
    public class Darbuotojas : User
    {
        
        
        public string Vardas { get; }
        public string Pavarde { get; }
        public List<int> AktyvusDarbai { get; private set; }
        public Darbuotojas(int id, string username, string password, string vardas, string pavarde) : base(id, username, password)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            AktyvusDarbai = new List<int>();
        }
        public Darbuotojas(int id, string username, string password, string vardas, string pavarde, List<int> darbai):base(id, username, password)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            AktyvusDarbai = darbai;
        }
    }
}
