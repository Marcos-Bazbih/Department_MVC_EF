using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Department_MVC_EF.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seniority { get; set; }
        public string Position { get; set; }
    }
}