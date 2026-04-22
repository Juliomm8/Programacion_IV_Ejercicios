using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenPracticoSailorMoon.Models
{
    public class Aliado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre del Aliado")]
        public string NombreAliado { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [StringLength(50, ErrorMessage = "El tipo no puede tener más de 50 caracteres")]
        public string Tipo { get; set; }

            [Required(ErrorMessage = "La edad es obligatoria.")]
            [Range(1, 500, ErrorMessage = "La edad debe estar entre 1 y 500 años.")]
        public int? Edad { get; set; }

        public int SailorSenshiId { get; set; }
        public SailorSenshi SailorSenshi { get; set; }


    }
}