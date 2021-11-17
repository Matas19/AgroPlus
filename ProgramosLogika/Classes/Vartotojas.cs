using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika.Classes
{
    public class Vartotojas
    {
        public int Id { get; }
        public string Vardas { get; }
        public string Pavarde { get; }
        public string Pareigos { get; }
        public string Username { get; }
        //konstruktorius skirtas sukurti objekta, kuris pernestu duomenis i DB
        public Vartotojas(string vardas, string pavarde, string pareigos, string username)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Pareigos = pareigos;
            Username = username;
        }
        //konstruktorius skirtas sukurti objekta, kuris butu vartojas UI valdyme
        public Vartotojas(int id, string vardas, string pavarde, string pareigos, string username)
        {
            Id = id;
            Vardas = vardas;
            Pavarde = pavarde;
            Pareigos = pareigos;
            Username = username;
        }

    }
}
