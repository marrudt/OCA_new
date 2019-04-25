using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class VigenciaSoat
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        public int CodVigencia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Vigencia SOAT")]
        public string DesVigencia { get; set; }

        public bool Activo { get; set; }
    }
}