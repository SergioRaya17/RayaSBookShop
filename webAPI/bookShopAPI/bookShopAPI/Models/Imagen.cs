using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Imagenes")]
    public class Imagen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Url { get; set; } = null!;

        [MaxLength(100)]
        public string? Descripcion { get; set; }
        
        public string? LibroISBN { get; set; } = null!;

        public bool EsPortada { get; set; }

        public Libro? Libro { get; set; }
    }
}