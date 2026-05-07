using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiEscuela.Models
{
    public class Facultades
    {
        [Key]
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public String Ubicacion { get; set; }


    }
}