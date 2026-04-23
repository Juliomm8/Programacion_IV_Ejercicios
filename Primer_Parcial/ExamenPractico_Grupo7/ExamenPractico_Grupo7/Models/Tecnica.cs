using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenPractico_Grupo7.Models
{
    public class Tecnica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la técnica es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre de la técnica no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre de la Técnica")]
        public string NombreTecnica { get; set; }

        [Required(ErrorMessage = "El tipo de técnica es obligatorio")]
        [StringLength(50, ErrorMessage = "El tipo de técnica no puede tener más de 50 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El nivel de daño es obligatorio")]
        [Range(1, 100, ErrorMessage = "El nivel de daño debe estar entre 1 y 100")]
        [Display(Name = "Nivel de Daño")]
        public int NivelDano { get; set; }

        public int GuerreroId { get; set; }
        public Guerrero Guerrero { get; set; }
    }
}