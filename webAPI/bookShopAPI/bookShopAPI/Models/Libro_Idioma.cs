using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Libros_Idiomas")]
    public class Libro_Idioma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LibroISBN { get; set; } = null!;

        [Required]
        public int IdiomaId { get; set; }

        public Libro? Libro { get; set; }
        public Idioma? Idioma { get; set; }
    }
}
