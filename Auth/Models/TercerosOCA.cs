using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class TercerosOCA
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nit Cliente")]
        public string nit { get; set; }

        [Display(Name = "DV")]
        public string digito { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nombre Cliente")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Teléfono")]
        public string telefono_1 { get; set; }

        [Display(Name = "Teléfono 2")]
        public string telefono_2 { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Tipo_id")]
        public string tipo_identificacion { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "País")]
        public string pais { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Correo Electrónico")]
        public string mail { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }
    }
}