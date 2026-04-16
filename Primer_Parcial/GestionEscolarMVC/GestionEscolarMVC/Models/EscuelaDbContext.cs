using System.Data.Entity;

namespace GestionEscolarMVC.Models
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext() : base("name=EscuelaDbContext") { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
    }
}