using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPracticoMarioBros.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El reino es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El reino debe tener entre 2 y 50 caracteres")]
        public string Reino { get; set; }

        [Required(ErrorMessage = "El nivel de poder es obligatorio")]
        [Range(1, 100, ErrorMessage = "El nivel de poder debe estar entre 1 y 100")]
        [Display(Name = "Nivel de Poder")]
        public int NivelPoder { get; set; }

        [Required(ErrorMessage = "La habilidad especial es obligatoria")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La habilidad especial debe tener entre 5 y 100 caracteres")]
        [Display(Name = "Habilidad Especial")]
        public string HabilidadEspecial { get; set; }
    }
}