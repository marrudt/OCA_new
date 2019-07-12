using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        public string Numero { get; set; }
        public string OC { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Cliente")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nombre Comprador")]
        public string Comprador { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Fecha Solicitud")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Segmento")]
        public int IdSegmento { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Detalle")]
        public int IdDetalle { get; set; }
        
        [Display(Name = "Adecuación (Solo Vh Especial)")]
        public int? IdAdecuacion { get; set; } 

        [Display(Name = "Intervalo de Precio")]
        public string IntervaloPrecio { get; set; }

        public string Transmision { get; set; }

        public int Unidades { get; set; }

        public string Modelo { get; set; }

        [Display(Name = "Mantenimiento Preventivo")]
        public string MttoPreventivo { get; set; }

        [Display(Name = "Requerimiento Matricula")]
        public bool ReqMatricula { get; set; }

        [Display(Name = "Impuesto Rodamiento")]
        public bool ImpuestoRodamiento { get; set; }

        public bool Soat { get; set; }

        [Display(Name = "Vigencia Soat")]
        public string Vigencia{ get; set; }

        [Display(Name = "Gravámenes Adicionales")]
        public bool GravamenesAdicionales { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notas { get; set; }

        public bool Adjudicado { get; set; }

        public bool Perdido { get; set; }

        public bool Cancelado { get; set; }
    }
}