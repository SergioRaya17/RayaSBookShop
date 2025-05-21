namespace bookShopAPI.DTO
{
    public class AutorCompletoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ImagenUrl { get; set; }
        public string? Biografia { get; set; } // Puedes usar frase célebre o texto corto

        public List<LibroDTO> Libros { get; set; } = new();
    }

    public class LibroDTO
    {
        public string ISBN { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? ImagenUrl { get; set; }
    }
}