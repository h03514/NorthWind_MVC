using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWind_MVC.Models
{
    public class HomeViewModel
    {

        /// <summary>
        /// Category
        /// </summary>
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Display(Name = "行動電話")]
        [RegularExpression(@"^((0{1}[2-9]{1,3}-)|(0{1}[2-9]{1,3}))\d{7,8}$", ErrorMessage = "＊電話號碼格式錯誤")]
        public string Description { get; set; }



        /// <summary>
        /// Account
        /// </summary>
        public string xUserName { get; set; }

        [Display(Name = "行動電話")]
        [RegularExpression(@"^((0{1}[2-9]{1,3}-)|(0{1}[2-9]{1,3}))\d{7,8}$", ErrorMessage = "＊電話號碼格式錯誤")]
        public string xPhone { get; set; }
    }
}