using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Libros")]
    public class Libro
    {
        [Key]
        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; } = null!;

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        [Precision(6,2)]
        public decimal Precio { get; set; }

        [Required]
        public int NumeroPaginas { get; set; }

        [Required]
        public int Stock { get; set; }

        public ICollection<Libro_Autor>? LibroAutores { get; set; }
        public ICollection<Libro_Categoria>? LibroCategorias { get; set; }
        public ICollection<Libro_Idioma>? LibroIdiomas { get; set; }
        public ICollection<Libro_Pedido>? LibrosPedidos { get; set; }
    }
}
