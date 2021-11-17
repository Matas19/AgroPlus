using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramosLogika.Classes
{
    public class Laukas
    {
        public int Id { get; }
        public string Pavadinimas { get; private set; }
        public string Vieta { get; }
        public string Aprasymas { get; private set; }
        public Laukas(string pav, string vieta, string aprasymas)
        {
            Pavadinimas = pav;
            Vieta = vieta;
            Aprasymas = aprasymas;
        }
        public Laukas(int id, string pav, string vieta, string aprasymas)
        {
            Id = id;
            Pavadinimas = pav;
            Vieta = vieta;
            Aprasymas = aprasymas;
        }
    }
}
