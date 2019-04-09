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
        public int IdSegmento { get; set; }  
        
        public string DesSegmento { get; set; }

        public bool Activo { get; set; }
    }
}