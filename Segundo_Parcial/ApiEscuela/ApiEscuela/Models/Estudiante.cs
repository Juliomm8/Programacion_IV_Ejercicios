using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiEscuela.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

    }
}