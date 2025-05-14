using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookShopAPI.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Importe { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public ICollection<Libro_Pedido>? LibrosPedidos { get; set; }
    }
}
