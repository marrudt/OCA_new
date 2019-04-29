using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Detalle
    {
        [Key]
        [Display(Name = "Código")]
        public int IdDetalle { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Detalle")]
        public string DesDetalle { get; set; }

        [Display(Name = "Segmento")]
        public int IdSegmento { get; set; }

        public bool Activo { get; set; }
    }
}