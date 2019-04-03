using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class GestionCartera
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Fecha Gestión")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_gestion { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Contacto Gestión")]
        public string contacto_gestion { get; set; }

        [Display(Name = "Teléfono Contacto Gestión")]
        public string telefono_contacto_gestion { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no Válido")]
        [Display(Name = "Email Contacto Gestión")]
        public string mail_contacto_gestion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Observaciones")]
        public string observacion_gestion { get; set; }

        [Display(Name = "Responsable Gestión")]
        public string responsable_gestion { get; set; }
    }
}