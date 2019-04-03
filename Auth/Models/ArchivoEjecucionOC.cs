using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ArchivoEjecucionOC
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int EjecucionOCId { get; set; }

        public virtual EjecucionOC EjecucionOCs { get; set; }
    }
}