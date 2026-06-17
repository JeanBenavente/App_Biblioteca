using App_Biblioteca.Application.Interfaces;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Structure.Data;
using App_Biblioteca.Structure.Repositories;

namespace App_Biblioteca.Structure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BibliotecaDbContext _context;

    public UnitOfWork(BibliotecaDbContext context)
    {
        _context = context;
        Libros = new Repository<Libro>(_context);
        Autores = new Repository<Autor>(_context);
        Categorias = new Repository<Categoria>(_context);
        Editoriales = new Repository<Editorial>(_context);
        Usuarios = new Repository<Usuario>(_context);
        Prestamos = new Repository<Prestamo>(_context);
    }

    public IRepository<Libro> Libros { get; }

    public IRepository<Autor> Autores { get; }

    public IRepository<Categoria> Categorias { get; }

    public IRepository<Editorial> Editoriales { get; }

    public IRepository<Usuario> Usuarios { get; }

    public IRepository<Prestamo> Prestamos { get; }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
