using Microsoft.AspNetCore.Mvc;
using seanceTP3.Models;
using System.Data.SQLite;
using System.Dynamic;

namespace seanceTP3.Controllers
{
    public class Person : Controller
    {
        public IActionResult all()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.People = Personal_infoModel.GetAllPerson();
            return View(mymodel);
        }
        public IActionResult getByid(int id)
        {
            PersonModel p = Personal_infoModel.getPerson(id);
            return View(p);
        }

        public IActionResult search()
        {
            return View();
        }
        public IActionResult searchResult(string first_name , string country)
        {
            int id = -1;
            SQLiteConnection con = new SQLiteConnection(@"Data source=D:\Documents\TPSGL3\.net\2022 GL3 .NET Framework TP3 - SQLite database.db");
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM personal_info WHERE first_name = '" + first_name +"' AND country = '"+ country+ "' LIMIT 1", con);
            SQLiteDataReader reader = com.ExecuteReader();
            PersonModel p = new PersonModel();
            using (reader)
            {
                while (reader.Read())
                {
                    id = (int)reader["id"];
                }
            }
            return Redirect("~/Person/"+ id);
        }
    }
}
