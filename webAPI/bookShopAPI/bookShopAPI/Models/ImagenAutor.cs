using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("ImagenesAutores")]
    public class ImagenAutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Url { get; set; } = null!;

        [MaxLength(100)]
        public string? Descripcion { get; set; }

        public int? AutorId { get; set; }

        public Autor? Autor { get; set; }
    }
}
