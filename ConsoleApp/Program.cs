using ProgramosLogika.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDB duombaze = new UserDB();
            Console.WriteLine("duombazes pajungimas");
            Console.WriteLine(duombaze.OpenConnection());
            //duombaze.AddAgro();
            Console.WriteLine("urename tikrinimas");
            Console.WriteLine(duombaze.CheckUsernameExists("cursor1"));
            //Vartotojas user = new Vartotojas("Matas", "Vaitkus", "Agronomas", "cursor");
            //duombaze.AddUser(user, "slaptazodis");
            Vartotojas user = duombaze.GetUser("tomela", "slaptazodi");
            if(user != null)
            {
                Console.WriteLine(user.Pareigos);
            }
            else
            {
                Console.WriteLine("nerastas useris");
            }

            Console.ReadKey();
        }
    }
}
