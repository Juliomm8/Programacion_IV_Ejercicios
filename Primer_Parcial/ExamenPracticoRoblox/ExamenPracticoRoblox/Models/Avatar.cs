using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPracticoRoblox.Models
{
    public class Avatar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El juego es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del juego no puede exceder los 100 caracteres")]
        public string Juego { get; set; }

        [Required(ErrorMessage = "El nivel de experiencia es obligatorio")]
        [Range(1, 100, ErrorMessage = "El nivel de experiencia debe estar entre 1 y 100")]
        [Display(Name = "Nivel de Experiencia")]
        public int NivelExperiencia { get; set; }

        [Required(ErrorMessage = "La habilidad especial es obligatoria")]
        [StringLength(100, ErrorMessage = "La habilidad especial no puede exceder los 100 caracteres")]
        [Display(Name = "Habilidad Especial")]
        public string HabilidadEspecial { get; set; }

    }
}