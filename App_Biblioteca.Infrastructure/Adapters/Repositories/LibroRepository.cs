using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class LibroRepository : GenericRepository<Libro>, ILibroRepository
{
    public LibroRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Libro>> GetAllAsync()
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .ToListAsync();
    }

    public override async Task<Libro?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Libro>> GetLibrosConDetallesAsync()
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .ToListAsync();
    }

    public async Task<Libro?> GetLibroConDetallesAsync(int id)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Libro>> BuscarPorTituloAsync(string titulo)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .Where(l => l.Titulo.Contains(titulo))
            .ToListAsync();
    }

    public async Task<IEnumerable<Libro>> BuscarPorAutorAsync(string autor)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .Where(l => l.Autor.Nombre.Contains(autor))
            .ToListAsync();
    }

    public async Task<IEnumerable<Libro>> BuscarPorCategoriaAsync(string categoria)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .Where(l => l.Categoria.Nombre.Contains(categoria))
            .ToListAsync();
    }

    public async Task<IEnumerable<Libro>> ObtenerDisponiblesAsync()
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .Where(l => l.Stock > 0)
            .ToListAsync();
    }

    public async Task<IEnumerable<Libro>> GetTopLibrosMasPrestadosAsync(int top = 10)
    {
        return await _dbSet
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Include(l => l.Editorial)
            .OrderByDescending(l => l.Prestamos.Count)
            .Take(top)
            .ToListAsync();
    }
}
