using NorthWind_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWind_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

        public ActionResult Index()
        {
            string str = "SELECT TOP 1000 * FROM [Northwind].[dbo].[Categories]";
            List<HomeViewModel> Food = new List<HomeViewModel>();

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            HomeViewModel home = new HomeViewModel
                            {
                                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                            };
                            Food.Add(home);
                        }
                        ViewBag.DataCheck = Food;
                    }
                    else
                    {
                        return View("資料庫為空");
                    }
                }
                connection.Close();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}