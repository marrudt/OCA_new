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
        public int IdDetalle { get; set; }

        public string DesDetalle { get; set; }

        public int IdSegmento { get; set; }

        public bool Activo { get; set; }
    }
}