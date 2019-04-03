using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    [Table("Segmentoes")]
    public class Segmento
    {
        public int Id { get; set; }

        public string DesSegmento { get; set; }   
        
        public bool Activo { get; set; }
    }
}