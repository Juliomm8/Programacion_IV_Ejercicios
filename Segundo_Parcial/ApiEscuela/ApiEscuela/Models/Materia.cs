using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiEscuela.Models
{
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
    }
}