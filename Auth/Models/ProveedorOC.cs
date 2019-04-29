using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class ProveedorOC
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "OC")]
        public string OC { get; set; }

        [Display(Name = "Fecha Orden Compra Automayor")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaOCAM { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Proveedor")]
        public string NitProveedor { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Concepto")]
        public string IdReferencia { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Valor Orden Compra Automayor")]
        public decimal? ValorOCAM { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "No. Orden Compra Automayor")]
        public string OCAM { get; set; }

        //[Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "No. Factura Proveedor")]
        public string FactProveedor { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Valor Factura Prov")]
        public decimal? ValorFactProv { get; set; }

        [Display(Name = "Fecha Factura Prov")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fechaFactProv { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }

        public virtual ICollection<ArchivoProveedorOC> ArchivoProveedorOCs { get; set; }
    }
}