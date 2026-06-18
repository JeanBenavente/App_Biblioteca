using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BibliotecaDbContext _context;
    private AutorRepository? _autores;
    private CategoriaRepository? _categorias;
    private EditorialRepository? _editoriales;
    private LibroRepository? _libros;
    private PrestamoRepository? _prestamos;
    private UsuarioRepository? _usuarios;
    private GenericRepository<Rol>? _roles;

    public UnitOfWork(BibliotecaDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Autor> Autores => 
        _autores ??= new AutorRepository(_context);

    public IGenericRepository<Categoria> Categorias => 
        _categorias ??= new CategoriaRepository(_context);

    public IGenericRepository<Editorial> Editoriales => 
        _editoriales ??= new EditorialRepository(_context);

    public IGenericRepository<Libro> Libros => 
        _libros ??= new LibroRepository(_context);

    public IGenericRepository<Prestamo> Prestamos => 
        _prestamos ??= new PrestamoRepository(_context);

    public IGenericRepository<Usuario> Usuarios => 
        _usuarios ??= new UsuarioRepository(_context);

    public IGenericRepository<Rol> Roles => 
        _roles ??= new GenericRepository<Rol>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
