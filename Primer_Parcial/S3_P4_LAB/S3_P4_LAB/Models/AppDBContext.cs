using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S3_P4_LAB.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("name=AppDBContext") {}
        public DbSet<Estudiante> Estudiantes { get; set; }


    }
}