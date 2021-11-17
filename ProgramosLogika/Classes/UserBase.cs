using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProgramosLogika.Classes
{
    public class UserBase
    {
        private string _path;
        private string _errorPath;

        public UserBase()
        {
            _path = "../DBs/users.txt";
            _errorPath = "../DBs/error.txt";
        }

        public List<User> ReadAllUsers(UserDB DB)
        {
            List<User> vartotojai = new List<User>();
            if (!File.Exists(_path))        //jei failas neegzistuoja grazina tuscia sarasa
            {
                return vartotojai;
            }

            try{
                string[] dataLine;
                using(StreamReader sr = new StreamReader(_path))
                {
                    while (!sr.EndOfStream)
                    {
                        dataLine = sr.ReadLine().Split(';');
                        if (dataLine[5] == "Darbuotojas")
                        {
                            AddWorkerToList(dataLine, DB);
                        }
                        else if (dataLine[5] == "Agronomas")
                        {

                        }
                        
                    }

                }
            }
            catch(Exception e)
            {
                IrasytiKlaida(e);
            }

            return vartotojai;
        }

        public void IrasytiKlaida(Exception e)
        {
            using(StreamWriter sw = new StreamWriter(_errorPath))
            {
                sw.WriteLine($"Ivyko klaida: {e.Message}");
            }
        }
        
        public void AddWorkerToList(string[] data, UserDB Db)
        {
            List<int> activeTaskList = new List<int>();
            if(data[6]!="" || data[6] != null)
            {
                foreach(string item in data[6].Split(','))
                {
                    activeTaskList.Add(Convert.ToInt32(item));
                    //Db.AddWorker(data[1], data[2], data[3], data[4], activeTaskList);
                }
            }
        }
        public void AgronomasToList(string[] data, UserDB Db)
        {
            
        }
       
    }
}
