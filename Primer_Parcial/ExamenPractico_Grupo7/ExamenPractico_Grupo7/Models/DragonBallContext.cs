using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenPractico_Grupo7.Models
{
    public class DragonBallContext : DbContext
    {
        public DragonBallContext() : base("name=DragonBallContext")
        {
        }
        public DbSet<Guerrero> Guerreros { get; set; }
        public DbSet<Tecnica> Tecnicas { get; set; }
    }
}