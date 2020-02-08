using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspCrud.Models
{
    public class UserInfo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required (ErrorMessage = "This field cannot be empty")]
        [EmailAddress (ErrorMessage = "Enter valid Email ID")]
        public string Email { get; set; }

        [Required (ErrorMessage = "This field cannot be empty")]
        [Display(Name = "Password")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Enter a valid password")]
        //[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&_+-=]{6,16}$", ErrorMessage = "Enter a valid password")]
        public string Passwd { get; set; }
    }
}