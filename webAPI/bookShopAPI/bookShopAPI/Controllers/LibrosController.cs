using bookShopAPI.Context;
using bookShopAPI.DTO;
using bookShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros
                .Include(l => l.LibroAutores)
                .Include(l => l.LibroCategorias)
                .Include(l => l.LibroIdiomas)
                .ToListAsync();
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<Libro>> GetLibro(string isbn)
        {
            var libro = await _context.Libros
                .Include(l => l.LibroAutores)
                .Include(l => l.LibroCategorias)
                .Include(l => l.LibroIdiomas)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);

            if (libro == null) return NotFound();

            return libro;
        }

        [HttpGet("ultimos/{cantidad}")]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetUltimosLibros(int cantidad)
        {
            var libros = await _context.Libros
                .Include(l => l.Imagenes)
                .OrderByDescending(l => l.FechaCreacion)
                .Take(cantidad)
                .Select(l => new LibroDTO
                {
                    ISBN = l.ISBN,
                    Titulo = l.Titulo,
                    ImagenUrl = l.Imagenes
                        .Where(img => img.EsPortada)
                        .Select(img => img.Url)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(libros);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetTodosLosLibros()
        {
            var libros = await _context.Libros
                .Include(l => l.Imagenes)
                .Select(l => new LibroDTO
                {
                    ISBN = l.ISBN,
                    Titulo = l.Titulo,
                    ImagenUrl = l.Imagenes != null
                        ? l.Imagenes
                            .Where(img => img.EsPortada)
                            .Select(img => img.Url)
                            .FirstOrDefault()
                        : null
                })
                .ToListAsync();

            return Ok(libros);
        }


        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            if (libro.Imagenes != null)
            {
                foreach (var imagen in libro.Imagenes)
                {
                    imagen.LibroISBN = libro.ISBN;
                }
            }

            libro.FechaCreacion = DateTime.Now;

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Libro creado correctamente", isbn = libro.ISBN });
        }

        [HttpPost("asignar-categoria")]
        public async Task<IActionResult> AsignarCategoria([FromBody] LibroCategoriaDTO dto)
        {
            var existeLibro = await _context.Libros.AnyAsync(l => l.ISBN == dto.LibroISBN);
            var existeCategoria = await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId);

            if (!existeLibro || !existeCategoria)
                return NotFound("El libro o la categoría no existen.");

            var relacion = new Libro_Categoria
            {
                LibroISBN = dto.LibroISBN,
                CategoriaId = dto.CategoriaId
            };

            _context.LibroCategorias.Add(relacion);
            await _context.SaveChangesAsync();

            return Ok("Categoría asignada al libro.");
        }

        [HttpPut("{isbn}")]
        public async Task<IActionResult> PutLibro(string isbn, Libro libro)
        {
            if (isbn != libro.ISBN)
                return BadRequest();

            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteLibro(string isbn)
        {
            var libro = await _context.Libros.FindAsync(isbn);
            if (libro == null) return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
