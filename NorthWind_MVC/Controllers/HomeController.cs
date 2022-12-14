using Microsoft.Ajax.Utilities;
using NorthWind_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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

        [HttpPost]
        public ActionResult Insert(HomeViewModel home )
        {
            string xUserName = home.xUserName;
            string xPhone = home.xPhone;

            string str = "insert into xAccount(xUserName, xPhone) values('" + xUserName + "', '" + xPhone + "')";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@xUserName", home.xUserName);
                    command.Parameters.AddWithValue("@xPhone", home.xPhone);
                    command.ExecuteNonQuery();
                }
            }

            str = "SELECT TOP 1000 * FROM [Northwind].[dbo].xAccount";
            List<HomeViewModel>homeViewModels= new List<HomeViewModel>();
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
                           home = new HomeViewModel
                            {
                                xUserName = reader.GetString(reader.GetOrdinal("xUserName")),
                                xPhone = reader.GetString(reader.GetOrdinal("xPhone")),
                            };
                            homeViewModels.Add(home);
                        }
                        //ViewBag.DataCheck = homeViewModels;
                    }
                    else
                    {
                        return View("資料庫為空");
                    }
                }
                connection.Close();
            }
            return View(home);
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