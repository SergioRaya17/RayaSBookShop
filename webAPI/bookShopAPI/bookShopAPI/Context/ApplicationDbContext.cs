using bookShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookShopAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Many-to-Many: Libro <-> Autor
            modelBuilder.Entity<Libro_Autor>()
                .HasKey(la => new { la.LibroISBN, la.AutorId });

            modelBuilder.Entity<Libro_Autor>()
                .HasOne(la => la.Libro)
                .WithMany(l => l.LibroAutores)
                .HasForeignKey(la => la.LibroISBN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Libro_Autor>()
                .HasOne(la => la.Autor)
                .WithMany(a => a.LibroAutores)
                .HasForeignKey(la => la.AutorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Many-to-Many: Libro <-> Categoria
            modelBuilder.Entity<Libro_Categoria>()
                .HasKey(lc => new { lc.LibroISBN, lc.CategoriaId });

            modelBuilder.Entity<Libro_Categoria>()
                .HasOne(lc => lc.Libro)
                .WithMany(l => l.LibroCategorias)
                .HasForeignKey(lc => lc.LibroISBN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Libro_Categoria>()
                .HasOne(lc => lc.Categoria)
                .WithMany(c => c.LibroCategorias)
                .HasForeignKey(lc => lc.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Many-to-Many: Libro <-> Idioma
            modelBuilder.Entity<Libro_Idioma>()
                .HasKey(li => new { li.LibroISBN, li.IdiomaId });

            modelBuilder.Entity<Libro_Idioma>()
                .HasOne(li => li.Libro)
                .WithMany(l => l.LibroIdiomas)
                .HasForeignKey(li => li.LibroISBN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Libro_Idioma>()
                .HasOne(li => li.Idioma)
                .WithMany(i => i.LibroIdiomas)
                .HasForeignKey(li => li.IdiomaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Many-to-Many con datos adicionales: Libro <-> Pedido (LibroPedido)
            modelBuilder.Entity<Libro_Pedido>()
                .HasKey(lp => new { lp.LibroISBN, lp.PedidoId });

            modelBuilder.Entity<Libro_Pedido>()
                .HasOne(lp => lp.Libro)
                .WithMany(l => l.LibrosPedidos)
                .HasForeignKey(lp => lp.LibroISBN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Libro_Pedido>()
                .HasOne(lp => lp.Pedido)
                .WithMany(p => p.LibrosPedidos)
                .HasForeignKey(lp => lp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Pedido <-> Usuario
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Libro> Libros => Set<Libro>();
        public DbSet<Autor> Autores => Set<Autor>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Idioma> Idiomas => Set<Idioma>();

        public DbSet<Libro_Autor> LibroAutores => Set<Libro_Autor>();
        public DbSet<Libro_Categoria> LibroCategorias => Set<Libro_Categoria>();
        public DbSet<Libro_Idioma> LibroIdiomas => Set<Libro_Idioma>();
        public DbSet<Libro_Pedido> LibrosPedidos => Set<Libro_Pedido>();
    }
}
