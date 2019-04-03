using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class IntervaloPrecio
    {
        public int Id { get; set; }

        public int CodIntervalo { get; set; }

        public string DesIntervalo { get; set; }

        public bool Activo { get; set; }
    }
}