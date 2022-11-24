using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWind_MVC.Models
{
    public class HomeViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}