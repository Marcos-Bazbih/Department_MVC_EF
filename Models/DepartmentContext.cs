using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Department_MVC_EF.Models
{
    public partial class DepartmentContext : DbContext
    {
        public DepartmentContext()
            : base("name=DepartmentContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> managers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
