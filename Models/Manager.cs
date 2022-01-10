using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Department_MVC_EF.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seniority { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}