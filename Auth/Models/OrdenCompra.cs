using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Cliente")]
        public string nit { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Emisión")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_emision { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_vencimiento { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_vencimiento_nueva { get; set; }

        [Display(Name = "Cambio Fecha Vencimiento")]
        public bool cambio_fecha { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Ordenador del Gasto")]
        public string ordenador_gasto { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Supervisor")]
        public string supervisor { get; set; }

        [Display(Name = "Teléfono 1")]
        public string telefono_1 { get; set; }

        [Display(Name = "Extensión")]
        public string ext_1 { get; set; }

        [Display(Name = "Teléfono 2")]
        public string telefono_2 { get; set; }

        [Display(Name = "Extensión")]
        public string ext_2 { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no Válido")]
        [Display(Name = "Email Ordenador Gasto")]
        public string mail_ordenador_gasto { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Correo no Válido")]
        [Display(Name = "Email Supervisor")]
        public string mail_supervisor { get; set; }

        [Required(ErrorMessage = "Obligatorio")]        
        public int? Unidades { get; set; }

        public string Modelo { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Valor")]
        public decimal? ValorOC { get; set; }

        [Display(Name = "Número AZ")]
        public string numero_AZ { get; set; }

        [Display(Name = "Estimación Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_pago { get; set; }

        [Display(Name = "Recaudo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_recaudo { get; set; }

        [Display(Name = "RC/Documento")]
        public string Documento { get; set; }

        [Display(Name = "Llegada Comprobante Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_llegada_comp_pago { get; set; }

        [Display(Name = "Solicitud Comprobante Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_solicitud_comp_pago { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }

        public virtual ICollection<ArchivoOC> ArchivoOCs { get; set; }
    }
}