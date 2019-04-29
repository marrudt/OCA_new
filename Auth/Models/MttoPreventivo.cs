using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class MttoPreventivo
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        public int CodMtto { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Descripción Mantenimiento Preventivo")]
        public string DesMtto { get; set; }

        public bool Activo { get; set; }
    }
}