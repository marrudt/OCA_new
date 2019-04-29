using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Adecuacion
    {
        [Key]
        [Display(Name = "Código")]
        public int IdAdecuacion { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Adecuación")]
        public string DesAdecuacion { get; set; }

        [Display(Name = "Detalle")]
        public int IdDetalle { get; set; }

        public bool Activo { get; set; }
    }
}