using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Libros_Pedidos")]
    public class Libro_Pedido
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string LibroISBN { get; set; } = null!;

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public Libro? Libro { get; set; }
        public Pedido? Pedido { get; set; }
    }
}
