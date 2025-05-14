using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Libros_Autores")]
    public class Libro_Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LibroISBN { get; set; } = null!;

        [Required]
        public int AutorId { get; set; }

        public Libro? Libro { get; set; }
        public Autor? Autor { get; set; }
    }
}
