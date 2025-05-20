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
        [MaxLength(2000)] 
        public string? Sinopsis { get; set; }

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        [Precision(6,2)]
        public decimal Precio { get; set; }

        [Required]
        public int NumeroPaginas { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public ICollection<Libro_Autor>? LibroAutores { get; set; }
        public ICollection<Libro_Categoria>? LibroCategorias { get; set; }
        public ICollection<Libro_Idioma>? LibroIdiomas { get; set; }
        public ICollection<Libro_Pedido>? LibrosPedidos { get; set; }
        public ICollection<Imagen>? Imagenes { get; set; }

    }
}
