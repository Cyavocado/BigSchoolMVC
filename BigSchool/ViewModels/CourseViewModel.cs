using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string heading { get; set; }

        public string action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }


        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }


        public DateTime GetDateTime()
        {
            string D = Date;
            string S = Time;
            return DateTime.ParseExact(D, "dd/M/yyyy", CultureInfo.InvariantCulture);

        }
    }
}