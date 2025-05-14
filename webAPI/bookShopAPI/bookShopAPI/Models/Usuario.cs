using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Apellidos { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Correo { get; set; } = null!;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; } = null!;

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaModificacion { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
