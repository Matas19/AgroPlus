using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika.Classes
{
    public class Darbas
    {
        public int Id { get; }
        public string Pavadinimas { get; private set; }
        public string Aprasymas { get; private set; }
        public DateTime Data { get; }
        public int Baigtumas { get; private set; }
        public Vartotojas User { get; }
        public Laukas Field { get; }
        
        //konstruktorius naudojamas sukurti objekta, kuris bus naudojamas duomenu pernesimui i DB
        public Darbas(string pavadinimas, string aprasymas, DateTime date, Laukas field)
        {
  
            Pavadinimas = pavadinimas;
            Aprasymas = aprasymas;
            Data = date;
            Field = field;
            Baigtumas = 0;
        }
        //konstruktorius naudojamas sukurti objekta, kuris bus naudojamas kaip informacijos saltinis
        public Darbas(int id, string pavadinimas, string aprasymas, int baigtumas, DateTime date, Vartotojas user, Laukas field)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Aprasymas = aprasymas;
            Baigtumas = baigtumas;
            Data = date;
            User = user;
            Field = field;
        }
    }
}
