using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ExamenPracticoRoblox.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del item es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del item no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre del Item")]
        public string NombreItem { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(50, ErrorMessage = "La categoría no puede exceder los 50 caracteres")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio en Robux es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio en Robux debe ser un número positivo")]
        [Display(Name = "Precio de Robux")]
        public int PrecioRobux { get; set; }

        [Required(ErrorMessage = "El avatar es obligatorio")]
        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }

    }
}