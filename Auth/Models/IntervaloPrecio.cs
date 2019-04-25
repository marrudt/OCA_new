using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class IntervaloPrecio
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
                
        public int CodIntervalo { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Intervalo")]
        public string DesIntervalo { get; set; }

        public bool Activo { get; set; }
    }
}