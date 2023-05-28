using Newtonsoft.Json;
using NorthWind_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Messaging;

namespace NorthWind_MVC.Controllers
{
    public class APIController : Controller
    {
        private readonly string conStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

        // GET: API
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string AAA(string AA)
        {
            try
            {
                WebClient webClient = new WebClient();
                var data = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts");
                Member obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Member>(data);
                string jsonData = string.Empty;
                var objj = new Member();
                List<Member> homeViewModels= new List<Member>();

                if (obj != null)
                {
                    while (obj.id==100)
                    {
                        objj = new Member()
                        {
                            id = obj.id,
                            userId = obj.userId,
                            title = obj.title,
                            body = obj.body,
                        };
                        homeViewModels.Add(objj);
                    }

                }



                //foreach (var i in obj)
                //{
                //    objj = new Member()
                //    {
                //        id = data[i],
                //    };
                //    homeViewModels.Add(objj);

                //}
                jsonData=JsonConvert.SerializeObject(homeViewModels);


                return jsonData;
            }
            catch (Exception ex)
            {


                return ex.Message;
            }

        }

        public class Member
        {
            public int userId;
            public int id;
            public string title;
            public string body;
        }

    }
}