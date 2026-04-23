using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPractico_Grupo7.Models
{
    public class Guerrero
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "La raza es obligatoria")]
        [StringLength(50, ErrorMessage = "La raza no puede tener más de 50 caracteres")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "El nivel de poder es obligatorio")]
        [Range(1, 100, ErrorMessage = "El nivel de poder debe estar entre 1 y 100")]
        [Display(Name = "Nivel de Poder")]
        public int NivelPoder { get; set; }

        [Required(ErrorMessage = "La transformación es obligatoria")]
        [StringLength(50, ErrorMessage = "La transformación no puede tener más de 50 caracteres")]
            public string Transformacion { get; set; }

    }
}