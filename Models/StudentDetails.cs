using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspCrud.Models
{
    public class StudentDetails
    {
        public int ID { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Enter a valid student name")]
        public string Name { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "This field cannot be empty")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a valid department name")]
        public string Department { get; set; }
    }
}