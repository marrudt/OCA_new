using Auth.Models;
using Auth.Repositorio;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Auth.Models
{
    [Table("Usuarios_OCA")]
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Clave { get; set; }

        [Required]
        public bool Bloqueado { get; set; }       
    }
}
