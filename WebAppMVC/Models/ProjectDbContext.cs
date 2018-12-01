using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Simcard> Simcards { get; set; }
    }
}