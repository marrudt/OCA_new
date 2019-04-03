using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Transmision
    {
        public int Id { get; set; }

        public int CodTransmision { get; set; }

        public string DesTransmision { get; set; }

        public bool Activo { get; set; }
    }
}