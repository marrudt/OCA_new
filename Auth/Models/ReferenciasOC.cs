using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ReferenciasOC
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Activo")]
        public bool activo { get; set; }
    }
}