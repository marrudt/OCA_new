using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class CarteraOC
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Cliente")]
        public string nombres { get; set; }

        [Display(Name = "Fecha Limite de Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_limite_pago { get; set; }

        [Display(Name = "Reportado CCE")]
        public bool se_reporta_cce { get; set; }

        [Display(Name = "Reporte CCE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_reporte_cce { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Detalle Reporte CCE")]
        public string reporte_cce_am { get; set; }

        [Display(Name = "Imagen")]
        public string imagen { get; set; }

        [Display(Name = "Envío Carta Recaudo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_envio_carta_pago { get; set; }

        [Display(Name = "Envío 2a Carta Recaudo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_envio_carta_pago_2 { get; set; }

        [Display(Name = "Radicación Cuenta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_radicacion_cuenta { get; set; }

        [Display(Name = "Fecha Problable de Recaudo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_probable_pago { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }

        public virtual ICollection<ArchivoCarteraOC> ArchivoCarteraOCs { get; set; }
    }
}