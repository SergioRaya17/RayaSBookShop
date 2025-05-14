using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Libros_Categorias")]
    public class Libro_Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LibroISBN { get; set; } = null!;

        [Required]
        public int CategoriaId { get; set; }

        public Libro? Libro { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
