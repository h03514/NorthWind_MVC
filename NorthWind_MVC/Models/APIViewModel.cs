using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWind_MVC.Models
{
    public class APIViewModel<T>
    {

        public string Code { get; set; }
        public bool Succ { get; set; }
        public DateTime DataTime { get; set; }
        public T Data { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public APIViewModel(T data)
        {
            Code = "0000";
            Succ = true;
            DataTime = DateTime.Now;
            Data = data;
        }
    }
}