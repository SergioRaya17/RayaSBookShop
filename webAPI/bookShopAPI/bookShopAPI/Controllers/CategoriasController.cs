using bookShopAPI.Context;
using bookShopAPI.DTO;
using bookShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            var categorias = await _context.Categorias
                .Select(c => new CategoriaDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                })
                .ToListAsync();

            return Ok(categorias);
        }

        [HttpGet("{id}/libros")]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetLibrosPorCategoria(int id)
        {
            var existe = await _context.Categorias.AnyAsync(c => c.Id == id);
            if (!existe)
                return NotFound("La categoría no existe.");

            var libros = await _context.LibroCategorias
                .Where(lc => lc.CategoriaId == id)
                .Include(lc => lc.Libro)
                    .ThenInclude(l => l.Imagenes)
                .Select(lc => new LibroDto
                {
                    ISBN = lc.Libro!.ISBN,
                    Titulo = lc.Libro.Titulo,
                    ImagenUrl = lc.Libro.Imagenes!
                        .Where(img => img.EsPortada)
                        .Select(img => img.Url)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(libros);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoriaDto)
        {
            var nuevaCategoria = new Categoria
            {
                Nombre = categoriaDto.Nombre
            };

            _context.Categorias.Add(nuevaCategoria);
            await _context.SaveChangesAsync();

            categoriaDto.Id = nuevaCategoria.Id; // actualiza el ID con el generado

            return CreatedAtAction(nameof(GetCategorias), new { id = categoriaDto.Id }, categoriaDto);
        }
    }
}
