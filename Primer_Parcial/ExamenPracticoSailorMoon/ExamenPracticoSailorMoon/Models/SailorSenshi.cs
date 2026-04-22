using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPracticoSailorMoon.Models
{
    public class SailorSenshi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El planeta es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El planeta debe tener entre 2 y 50 caracteres")]
        public string Planeta { get; set; }

        [Required(ErrorMessage = "El nivel de poder es obligatorio.")]
        [Range(1, 10000, ErrorMessage = "El nivel de poder debe estar entre 1 y 10,000.")]
        [Display(Name = "Nivel de Poder")]
        public int NivelPoder { get; set; }

        [Required(ErrorMessage = "Debes ingresar al menos una habilidad especial.")]
        [StringLength(150, ErrorMessage = "La descripción de la habilidad es muy larga (máximo 150 caracteres).")]
        [Display(Name = "Habilidad Especial")]
        public string HabilidadEspecial { get; set; }

    }
}