using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class EjecucionOC
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Display(Name = "Cliente")]
        public string nit { get; set; }

        //[Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Fecha Probable Entrega")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_probable_entrega { get; set; }

        //[Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Fecha Entrega Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_entrega_final { get; set; }

        //[Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Funcionario Recibe")]
        public string funcionario_recibe { get; set; }

        //[Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Entrega Automayor")]
        public string entrega_am { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }

        public virtual ICollection<ArchivoEjecucionOC> ArchivoEjecucionOCs { get; set; }
    }
}