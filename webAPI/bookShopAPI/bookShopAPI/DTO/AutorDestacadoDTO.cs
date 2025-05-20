namespace bookShopAPI.DTO
{
    public class AutorDestacadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ImagenUrl { get; set; }
        public int CantidadLibros { get; set; }
    }
}
