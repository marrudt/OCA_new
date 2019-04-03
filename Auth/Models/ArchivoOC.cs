using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ArchivoOC
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int OCId { get; set; }

        public virtual OrdenCompra OrdenCompras { get; set; }
    }
}