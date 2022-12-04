using Microsoft.AspNetCore.Mvc;
using seanceTP3.Models;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;

namespace seanceTP3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SQLiteConnection con = new SQLiteConnection(@"Data source=" + System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory) +"2022 GL3 .NET Framework TP3 - SQLite database.db");
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM personal_info", con);
            SQLiteDataReader reader = com.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {

                    int id = (int)reader["id"];
                    string first_name = (string)reader["first_name"];
                    string last_name = (string)reader["last_name"];
                    string email = (string)reader["email"];
                    try {
                        string date_birth = (string)reader["date_birth"];
                        string image = (string)reader["image"];
                    }
                    catch (Exception e){}
                    string country = (string)reader["country"];
                    Debug.WriteLine(id + first_name + last_name + email + country);

                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}