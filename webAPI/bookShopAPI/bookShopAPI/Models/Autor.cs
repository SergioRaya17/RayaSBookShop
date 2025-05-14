using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Autores")]
    public class Autor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = null!;

        [MaxLength(1000)]
        public string? Biografia { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime? FechaFallecimiento { get; set; }

        public ICollection<Libro_Autor>? LibroAutores { get; set; }
    }
}
