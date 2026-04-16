using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionEscolarMVC.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }
        [Range(1, 120, ErrorMessage = "La edad debe ser un número entre 1 y 120.")]
        public int Edad { get; set; }
        [Required]
        public string Carrera { get; set; }
        [Required]
        public string Correo { get; set; }
        [Range(1, 10, ErrorMessage = "El semestre debe ser un número entre 1 y 10.")]
        public int Semestre { get; set; }= 0;
        

        public virtual ICollection<Universidad> Universidades { get; set; }
    }
}