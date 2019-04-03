using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class LineaVh
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Clase")]
        public string clase { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
    }
}