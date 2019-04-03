using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models
{
    [Table("Cilindrajes")]
    public class Cilindraje
    {
        public int Id { get; set; }

        public int IdSegmento { get; set; }

        public string DesCilindraje { get; set; }

        public bool Activo { get; set; }
    }
}