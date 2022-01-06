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
        public string Pavadinimas { get;}
        public string Aprasymas { get;}
        public DateTime Data { get; }
        public int Baigtumas { get;}
        public Vartotojas User { get; }
        public Laukas Field { get; }
        public string Uzimtumas { get; }
        public string Busena { get; }
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
            if (baigtumas == 0 && user == null) Busena = "nepradetas";
            else if (baigtumas == 0 && user != null) Busena = "pradetas";
            else Busena = "baigtas";
            if (user == null) Uzimtumas = "laisvas";
            else Uzimtumas = "uzimtas";
        }
    }
}
