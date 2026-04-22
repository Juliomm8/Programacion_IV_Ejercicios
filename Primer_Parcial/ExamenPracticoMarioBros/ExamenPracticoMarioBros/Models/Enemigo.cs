using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPracticoMarioBros.Models
{
    public class Enemigo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del enemigo es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre del enemigo debe tener entre 2 y 50 caracteres")]      
        [Display(Name = "Nombre del Enemigo")]
        public string NombreEnemigo { get; set; }

            [Required(ErrorMessage = "El tipo de enemigo es obligatorio")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "El tipo de enemigo debe tener entre 2 y 50 caracteres")]
            [Display(Name = "Tipo de Enemigo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El nivel de dificultad es obligatorio")]
        [Range(1, 10, ErrorMessage = "El nivel de dificultad debe estar entre 1 y 10")]
            [Display(Name = "Nivel de Dificultad")]

        public int NivelDificultad { get; set; }

        [Required(ErrorMessage = "El personaje asociado es obligatorio")]
        public int PersonajeId { get; set; }
        public Personaje Personaje { get; set; }
    }
}