using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class MttoPreventivo
    {
        public int Id { get; set; }

        public int CodMtto { get; set; }
        
        public string DesMtto { get; set; }

        public bool Activo { get; set; }
    }
}