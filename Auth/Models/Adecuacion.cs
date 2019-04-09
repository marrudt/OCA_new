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
        public int IdAdecuacion { get; set; }

        public string DesAdecuacion { get; set; }

        public int IdDetalle { get; set; }

        public bool Activo { get; set; }
    }
}