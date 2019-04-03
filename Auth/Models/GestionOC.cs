using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class GestionOC
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Display(Name = "Consulta Comparendos")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_consulta_comparendos { get; set; }

        [Display(Name = "Envío Carta Comparendos")]
        public bool envio_carta_comparendos { get; set; }

        [Display(Name = "Carta Supervisor")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_carta_supervisor { get; set; }

        [Display(Name = "Legalizado")]
        public bool se_legalizo { get; set; }

        [Display(Name = "Pagar Estampilla")]
        public bool estampilla_pagar { get; set; }

        [Display(Name = "Descuento Estampilla")]
        public bool estampilla_dcto { get; set; }

        [Display(Name = "Estampillas")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_estampilla { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Valor Estampillas")]
        public decimal? valor_estampilla { get; set; }

        [Display(Name = "Cierre Factura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_cierre_factura { get; set; }

        [Display(Name = "Entidad Matricula")]
        public string entidad_matricula { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }
    }
}