using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExamenPracticoSailorMoon.Models
{
    public class SailorMoonContext : DbContext
    {
        public SailorMoonContext() : base("name=SailorMoonContext") { }

        public DbSet<SailorSenshi> SailorSenshis { get; set; }
        public DbSet<Aliado> Aliados { get; set; }
    }
}