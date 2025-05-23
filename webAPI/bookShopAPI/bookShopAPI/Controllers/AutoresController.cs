﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookShopAPI.Context;
using bookShopAPI.Models;
using bookShopAPI.DTO;

namespace bookShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return await _context.Autores
                .Include(a => a.Imagenes)
                .ToListAsync();
        }

        // GET: api/autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autores
                .Include(a => a.Imagenes)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("destacados/{cantidad}")]
        public async Task<ActionResult<IEnumerable<AutorDestacadoDTO>>> GetAutoresDestacados(int cantidad)
        {
            var autores = await _context.Autores
                .Include(a => a.LibroAutores)
                .Include(a => a.Imagenes)
                .Select(a => new AutorDestacadoDTO
                {
                    Nombre = a.Nombre,
                    ImagenUrl = a.Imagenes!
                        .Where(img => img.esPrincipal)
                        .Select(img => img.Url)
                        .FirstOrDefault(),
                    CantidadLibros = a.LibroAutores!.Count
                })
                .OrderByDescending(a => a.CantidadLibros)
                .Take(cantidad)
                .ToListAsync();

            return Ok(autores);
        }

        [HttpGet("completos")]
        public async Task<ActionResult<IEnumerable<AutorCompletoDTO>>> GetAutoresCompletos()
        {
            var autores = await _context.Autores
                .Include(a => a.Imagenes)
                .Include(a => a.LibroAutores!)
                    .ThenInclude(la => la.Libro)
                    .ThenInclude(l => l.Imagenes)
                .Select(a => new AutorCompletoDTO
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    ImagenUrl = a.Imagenes
                        .Where(i => i.esPrincipal)
                        .Select(i => i.Url)
                        .FirstOrDefault(),
                    Biografia = a.Biografia,
                    Libros = a.LibroAutores!
                        .Select(la => new LibroDTO
                        {
                            ISBN = la.Libro!.ISBN,
                            Titulo = la.Libro.Titulo,
                            ImagenUrl = la.Libro.Imagenes!
                                .Where(i => i.EsPortada)
                                .Select(i => i.Url)
                                .FirstOrDefault()
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(autores);
        }



        // POST: api/autores
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor([FromBody] Autor autor)
        {
            if (autor.Imagenes != null)
            {
                foreach (var imagen in autor.Imagenes)
                {
                    imagen.Autor = autor;
                }
            }

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autor);
        }

        [HttpPost("asignar-libro")]
        public async Task<IActionResult> AsignarLibro([FromBody] AsignarLibroAutorDTO dto)
        {
            var autor = await _context.Autores.FindAsync(dto.AutorId);
            var libro = await _context.Libros.FindAsync(dto.LibroISBN);

            if (autor == null || libro == null)
                return NotFound("Autor o libro no encontrados.");

            var existeRelacion = await _context.LibroAutores
                .AnyAsync(la => la.AutorId == dto.AutorId && la.LibroISBN == dto.LibroISBN);

            if (existeRelacion)
                return BadRequest("La relación ya existe.");

            var nuevaRelacion = new Libro_Autor
            {
                AutorId = dto.AutorId,
                LibroISBN = dto.LibroISBN
            };

            _context.LibroAutores.Add(nuevaRelacion);
            await _context.SaveChangesAsync();

            return Ok("Libro asignado al autor correctamente.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, [FromBody] Autor autor)
        {
            if (id != autor.Id)
                return BadRequest("El ID del autor no coincide.");

            var autorExistente = await _context.Autores
                .Include(a => a.Imagenes)
                .Include(a => a.LibroAutores)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (autorExistente == null)
                return NotFound("Autor no encontrado.");

            // Solo se actualizan campos simples. Las relaciones se gestionan aparte.
            autorExistente.Nombre = autor.Nombre;
            autorExistente.Biografia = autor.Biografia;
            autorExistente.FechaNacimiento = autor.FechaNacimiento;
            autorExistente.FechaFallecimiento = autor.FechaFallecimiento;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores
                .Include(a => a.Imagenes)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
