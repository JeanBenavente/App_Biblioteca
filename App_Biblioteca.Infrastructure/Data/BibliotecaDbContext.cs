using System;
using System.Collections.Generic;
using App_Biblioteca.Structure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace App_Biblioteca.Structure.Data;

public partial class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext()
    {
    }

    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<autores> autores { get; set; }

    public virtual DbSet<categorias> categorias { get; set; }

    public virtual DbSet<editoriales> editoriales { get; set; }

    public virtual DbSet<libros> libros { get; set; }

    public virtual DbSet<prestamos> prestamos { get; set; }

    public virtual DbSet<roles> roles { get; set; }

    public virtual DbSet<usuarios> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=BibliotecaDigitalDB;user=root;password=piero", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.6.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<autores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Nombre, "IX_Autores_Nombre");

            entity.Property(e => e.Nacionalidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<editoriales>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Pais).HasMaxLength(100);
        });

        modelBuilder.Entity<libros>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AutorId, "FK_Libros_Autores");

            entity.HasIndex(e => e.CategoriaId, "FK_Libros_Categorias");

            entity.HasIndex(e => e.EditorialId, "FK_Libros_Editoriales");

            entity.HasIndex(e => e.ISBN, "ISBN").IsUnique();

            entity.HasIndex(e => e.Titulo, "IX_Libros_Titulo");

            entity.Property(e => e.ISBN).HasMaxLength(20);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Autor).WithMany(p => p.libros)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libros_Autores");

            entity.HasOne(d => d.Categoria).WithMany(p => p.libros)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libros_Categorias");

            entity.HasOne(d => d.Editorial).WithMany(p => p.libros)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Libros_Editoriales");
        });

        modelBuilder.Entity<prestamos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.LibroId, "IX_Prestamos_LibroId");

            entity.HasIndex(e => e.UsuarioId, "IX_Prestamos_UsuarioId");

            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Activo'")
                .HasColumnType("enum('Activo','Devuelto')");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.FechaPrestamo)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Libro).WithMany(p => p.prestamos)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Libros");

            entity.HasOne(d => d.Usuario).WithMany(p => p.prestamos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestamos_Usuarios");
        });

        modelBuilder.Entity<roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Correo, "Correo").IsUnique();

            entity.HasIndex(e => e.RolId, "FK_Usuarios_Roles");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Rol).WithMany(p => p.usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
