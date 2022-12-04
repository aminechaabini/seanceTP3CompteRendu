using System.Data.SQLite;
using System.Diagnostics;

namespace seanceTP3.Models
{
    public class Personal_infoModel
    {
        public static List<PersonModel> GetAllPerson()
        {
            List<PersonModel> l = new List<PersonModel>();
            SQLiteConnection con = new SQLiteConnection(@"Data source=" + System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory) + "2022 GL3 .NET Framework TP3 - SQLite database.db");
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM personal_info", con);
            SQLiteDataReader reader = com.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    PersonModel p = new PersonModel();
                    p.id = (int)reader["id"];
                    p.first_name = (string)reader["first_name"];
                    p.last_name = (string)reader["last_name"];
                    p.email = (string)reader["email"];
                    try
                    {
                        p.date_birth = (string)reader["date_birth"];
                        p.image = (string)reader["image"];
                    }
                    catch (Exception e) { }
                    p.country = (string)reader["country"];
                    l.Add(p);

                }
            }
            return l;
        }
        public static PersonModel getPerson(int id)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data source=" + System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory) + "2022 GL3 .NET Framework TP3 - SQLite database.db");
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM personal_info WHERE id="+id, con);
            SQLiteDataReader reader = com.ExecuteReader();
            PersonModel p = new PersonModel();
            using (reader)
            {
                while (reader.Read())
                {
                    p.id = (int)reader["id"];
                    p.first_name = (string)reader["first_name"];
                    p.last_name = (string)reader["last_name"];
                    p.email = (string)reader["email"];
                    try
                    {
                        p.date_birth = (string)reader["date_birth"];
                        p.image = (string)reader["image"];
                    }
                    catch (Exception e) { }
                    p.country = (string)reader["country"];
                

                }
            }
            if (p.id == id)
                return p;
            else return null;
        }
    }
}
