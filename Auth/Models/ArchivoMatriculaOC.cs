using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ArchivoMatriculaOC
    {
        public Guid Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public int MatriculaOCId { get; set; }

        public virtual ControlMatriculas ControlMatriculas { get; set; } 
    }
}