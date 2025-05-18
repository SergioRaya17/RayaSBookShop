using bookShopAPI.Context;
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

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibro), new { isbn = libro.ISBN }, libro);
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
