using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class EntidadMatricula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nit Entidad")]
        public string nit { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nombre Entidad")]
        public string nombres { get; set; }

        [Display(Name = "Activo")]
        public bool activo { get; set; }
    }
}