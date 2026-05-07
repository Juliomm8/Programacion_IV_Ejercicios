using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ApiEscuela.Models
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext() : base("name=EscuelaConnection"){}
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Facultades> Facultades { get; set; }
        
    }
}