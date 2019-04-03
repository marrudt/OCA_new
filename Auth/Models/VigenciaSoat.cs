using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class VigenciaSoat
    {
        public int Id { get; set; }

        public int CodVigencia { get; set; }

        public string DesVigencia { get; set; }

        public bool Activo { get; set; }
    }
}