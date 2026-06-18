using App_Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Data;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Editorial> Editoriales { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Nacionalidad).HasMaxLength(100);
            entity.HasMany(e => e.Libros).WithOne(l => l.Autor).HasForeignKey(l => l.AutorId);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.HasMany(e => e.Libros).WithOne(l => l.Categoria).HasForeignKey(l => l.CategoriaId);
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.HasMany(e => e.Libros).WithOne(l => l.Editorial).HasForeignKey(l => l.EditorialId);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(e => e.ISBN).HasMaxLength(20).IsRequired();
            entity.HasIndex(e => e.ISBN).IsUnique();
            entity.HasOne(e => e.Autor).WithMany(a => a.Libros).HasForeignKey(e => e.AutorId);
            entity.HasOne(e => e.Categoria).WithMany(c => c.Libros).HasForeignKey(e => e.CategoriaId);
            entity.HasOne(e => e.Editorial).WithMany(ed => ed.Libros).HasForeignKey(e => e.EditorialId);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Nombre).IsUnique();
            entity.HasMany(e => e.Usuarios).WithOne(u => u.Rol).HasForeignKey(u => u.RolId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Apellido).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Correo).HasMaxLength(150).IsRequired();
            entity.HasIndex(e => e.Correo).IsUnique();
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.HasOne(e => e.Rol).WithMany(r => r.Usuarios).HasForeignKey(e => e.RolId);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FechaPrestamo).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Estado).HasMaxLength(20).IsRequired().HasDefaultValue("Activo");
            entity.HasOne(e => e.Usuario).WithMany(u => u.Prestamos).HasForeignKey(e => e.UsuarioId);
            entity.HasOne(e => e.Libro).WithMany(l => l.Prestamos).HasForeignKey(e => e.LibroId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
