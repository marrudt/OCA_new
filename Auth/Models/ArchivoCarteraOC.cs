using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ArchivoCarteraOC
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int CarteraOCId { get; set; }

        public virtual CarteraOC CarteraOCs { get; set; }
    }
}