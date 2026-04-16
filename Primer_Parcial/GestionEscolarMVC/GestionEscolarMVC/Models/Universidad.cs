using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionEscolarMVC.Models
{
    public class Universidad
    {
        [Key]
        public int UniversidadId { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public string Rector { get; set; }
        [Range(1800, 9999, ErrorMessage = "El año de fundación debe ser un número de cuatro dígitos.")]
        public int AñoFundacion { get; set; }
        




        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}