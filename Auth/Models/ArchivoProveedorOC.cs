using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ArchivoProveedorOC
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int ProveedorOCId { get; set; }

        public virtual ProveedorOC ProveedorOCs { get; set; }
    }
}