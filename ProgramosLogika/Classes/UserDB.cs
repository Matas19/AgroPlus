using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProgramosLogika.Classes
{
    public class UserDB
    {
        private string _dataSource = @"DESKTOP-ECCE0GR\SQLEXPRESS01";  //db adresas
        private string _database = "AgroPlus";  //DB pavadinimas
        private string _connString;     //bendras connection strin
        private SqlConnection connection;   //naudojama prisijungti prie duomenu bazes
        private SqlCommand cmd;     //kintamasis naudojamas vykditi SQL query
        private SqlDataReader dr;   //rederis skirtas skaityti gautiem duomenim is DB
        public UserDB()
        {
            _connString = @"Data Source=" + _dataSource + ";Initial Catalog=" + _database + ";Trusted_Connection=True;";
        }
        public bool OpenConnection()    //atidaro conectiona su DB
        {
            try
            {
                connection = new SqlConnection(_connString);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public void AddUser(Vartotojas user, string pass)
        {
            using (cmd = new SqlCommand(@"INSERT INTO Vartotojas (Username, Password, Vardas, Pavarde, Pareigos) VALUES(@username, @password, @vardas, @pavarde, @pareigos);", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("username", user.Username));
                cmd.Parameters.Add(new SqlParameter("password", pass));
                cmd.Parameters.Add(new SqlParameter("vardas", user.Vardas));
                cmd.Parameters.Add(new SqlParameter("pavarde", user.Pavarde));
                cmd.Parameters.Add(new SqlParameter("pareigos", user.Pareigos));
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public bool CheckUsernameExists(string username)
        {
            using (cmd = new SqlCommand($"SELECT * FROM Vartotojas WHERE Username = '{username}'", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
            }
            return false;
        }
        public Vartotojas GetUser(string username, string password)
        {
            Vartotojas user;
            if (CheckUsernameExists(username))
            {
                using (cmd = new SqlCommand($"SELECT * FROM Vartotojas WHERE Username = '{username}' AND Password = '{password}'", connection))
                {
                    connection.Open();
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            user = new Vartotojas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
                            connection.Close();
                            return user;
                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }
                    }
                }
            }
            return null;
        }
        public List<Vartotojas> GetUsers()
        {
            List<Vartotojas> users = new List<Vartotojas>();
            Vartotojas user;
            using (cmd = new SqlCommand($"SELECT * FROM Vartotojas", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            user = new Vartotojas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
                            users.Add(user);
                        }
                    }
                }
                connection.Close();

            }
            return users;
        }
        public bool CheckFieldName(string name)
        {
            using (cmd = new SqlCommand($"SELECT * FROM Laukas WHERE Pavadinimas = '{name}'", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
            }
            return false;
        }
        public void AddField(Laukas field)
        {
            using (cmd = new SqlCommand(@"INSERT INTO Laukas (Pavadinimas, Vieta, Aprasymas) VALUES(@pavadinimas, @vieta, @aprasymas);", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("pavadinimas", field.Pavadinimas));
                cmd.Parameters.Add(new SqlParameter("vieta", field.Vieta));
                cmd.Parameters.Add(new SqlParameter("aprasymas", field.Aprasymas));
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Laukas> GetFields()
        {
            List<Laukas> fields = new List<Laukas>();
            Laukas field;
            using (cmd = new SqlCommand(@"SELECT * FROM Laukas", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            field = new Laukas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
                            fields.Add(field);
                        }
                    }
                }
                connection.Close();
            }
            return fields;
        }
        public void AddJob(Darbas job)
        {
            using (cmd = new SqlCommand(@"INSERT INTO Darbas (Pavadinimas, Aprasymas, Statusas, Data, FK_Laukas) VALUES (@pavadinimas, @aprasymas, @statusas, @data, @laukoId)", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("pavadinimas", job.Pavadinimas));
                cmd.Parameters.Add(new SqlParameter("aprasymas", job.Aprasymas));
                cmd.Parameters.Add(new SqlParameter("statusas", "0"));
                cmd.Parameters.Add(new SqlParameter("data", job.Data.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("laukoId", job.Field.Id));
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<Darbas> GetJobs()
        {
            List<Darbas> jobs = new List<Darbas>();
            List<Vartotojas> users = GetUsers();
            List<Laukas> fields = GetFields();
            Darbas job;
            using (cmd = new SqlCommand(@"SELECT * FROM Darbas ORDER BY Data", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int id = dr.GetInt32(0);
                            string pavadinimas = dr.GetString(1);
                            string aprasymas = dr.GetString(2);
                            bool statusasbool = dr.GetBoolean(3);
                            int statusas;
                            if (statusasbool)
                            {
                                statusas = 1;
                            }
                            else
                            {
                                statusas = 0;
                            }
                            DateTime date = dr.GetDateTime(4);
                            Vartotojas user;
                            if (dr[5] != DBNull.Value)
                            {
                                user = users.First(x => x.Id == dr.GetInt32(5));
                            }
                            else
                            {
                                user = null;
                            }
                            Laukas field = fields.First(x => x.Id == dr.GetInt32(6));
                            job = new Darbas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), statusas, dr.GetDateTime(4), user, field);
                            jobs.Add(job);
                        }
                    }
                }
                connection.Close();
            }
            return jobs;
        }
        public List<Darbas> GetJobsByField(Laukas laukas)
        {
            List<Darbas> jobs = new List<Darbas>();
            List<Vartotojas> users = GetUsers();
            List<Laukas> fields = GetFields();
            Darbas job;
            using (cmd = new SqlCommand($"SELECT * FROM Darbas WHERE FK_Laukas = {laukas.Id} ORDER BY Data", connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int id = dr.GetInt32(0);
                            string pavadinimas = dr.GetString(1);
                            string aprasymas = dr.GetString(2);
                            bool statusasbool = dr.GetBoolean(3);
                            int statusas;
                            if (statusasbool)
                            {
                                statusas = 1;
                            }
                            else
                            {
                                statusas = 0;
                            }
                            DateTime date = dr.GetDateTime(4);
                            Vartotojas user;
                            if (dr[5] != DBNull.Value)
                            {
                                user = users.First(x => x.Id == dr.GetInt32(5));
                            }
                            else
                            {
                                user = null;
                            }
                            Laukas field = fields.First(x => x.Id == dr.GetInt32(6));
                            job = new Darbas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), statusas, dr.GetDateTime(4), user, field);
                            jobs.Add(job);
                        }
                    }
                }
                connection.Close();
            }
            return jobs;
        }
        public List<Darbas> GetJobsByWorker(bool uzimtas)
        {
            List<Darbas> jobs = new List<Darbas>();
            List<Vartotojas> users = GetUsers();
            List<Laukas> fields = GetFields();
            Darbas job;
            string cmdLine;
            if (uzimtas) cmdLine = $"SELECT * FROM Darbas WHERE FK_Vartotojas IS NOT NULL ORDER BY Data";
            else cmdLine = $"SELECT * FROM Darbas WHERE FK_Vartotojas IS NULL  ORDER BY Data";
            using (cmd = new SqlCommand(cmdLine, connection))
            {
                connection.Open();
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int id = dr.GetInt32(0);
                            string pavadinimas = dr.GetString(1);
                            string aprasymas = dr.GetString(2);
                            bool statusasbool = dr.GetBoolean(3);
                            int statusas;
                            if (statusasbool)
                            {
                                statusas = 1;
                            }
                            else
                            {
                                statusas = 0;
                            }
                            DateTime date = dr.GetDateTime(4);
                            Vartotojas user;
                            if (dr[5] != DBNull.Value)
                            {
                                user = users.First(x => x.Id == dr.GetInt32(5));
                            }
                            else
                            {
                                user = null;
                            }
                            Laukas field = fields.First(x => x.Id == dr.GetInt32(6));
                            job = new Darbas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), statusas, dr.GetDateTime(4), user, field);
                            jobs.Add(job);
                        }
                    }
                }
                connection.Close();
            }
            return jobs;
        }
        public List<Darbas> GetJobsByWorkerId(int workerId, int stat)
        {
            List<Darbas> jobs = new List<Darbas>();
            List<Vartotojas> users = GetUsers();
            List<Laukas> fields = GetFields();
            Darbas job;
            using (cmd = new SqlCommand($"SELECT * FROM Darbas WHERE FK_Vartotojas = @workerId AND Statusas = @stat  ORDER BY Data", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("workerId", workerId));
                cmd.Parameters.Add(new SqlParameter("stat", stat));
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int id = dr.GetInt32(0);
                            string pavadinimas = dr.GetString(1);
                            string aprasymas = dr.GetString(2);
                            bool statusasbool = dr.GetBoolean(3);
                            int statusas;
                            if (statusasbool)
                            {
                                statusas = 1;
                            }
                            else
                            {
                                statusas = 0;
                            }
                            DateTime date = dr.GetDateTime(4);
                            Vartotojas user;
                            if (dr[5] != DBNull.Value)
                            {
                                user = users.First(x => x.Id == dr.GetInt32(5));
                            }
                            else
                            {
                                user = null;
                            }
                            Laukas field = fields.First(x => x.Id == dr.GetInt32(6));
                            job = new Darbas(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), statusas, dr.GetDateTime(4), user, field);
                            jobs.Add(job);
                        }
                    }
                }
                connection.Close();
            }
            return jobs;
        }
        public void AssignJob(int workerId, int jobId)
        {
            using (cmd = new SqlCommand(@"UPDATE Darbas SET FK_Vartotojas = @workerId WHERE PK_Id = @jobId", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("workerId", workerId));
                cmd.Parameters.Add(new SqlParameter("jobId", jobId));
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void FinishJob(int jobId)
        {
            using (cmd = new SqlCommand(@"UPDATE Darbas SET Statusas = 1 WHERE PK_Id = @jobId", connection))
            {
                connection.Open();
                cmd.Parameters.Add(new SqlParameter("jobId", jobId));
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}