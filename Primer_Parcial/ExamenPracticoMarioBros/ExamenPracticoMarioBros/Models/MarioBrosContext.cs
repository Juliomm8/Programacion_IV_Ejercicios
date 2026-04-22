using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ExamenPracticoMarioBros.Models
{
    public class MarioBrosContext : DbContext
    {
        public MarioBrosContext() : base("name=MarioBrosContext")
        {
        }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Enemigo> Enemigos { get; set; }
    }
}