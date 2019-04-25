using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Segmento
    {
        [Key]
        [Display(Name = "Código")]
        public int IdSegmento { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Segmento")]
        public string DesSegmento { get; set; }

        public bool Activo { get; set; }
    }
}