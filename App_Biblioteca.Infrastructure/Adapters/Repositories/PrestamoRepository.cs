using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
{
    public PrestamoRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Prestamo>> GetAllAsync()
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .ToListAsync();
    }

    public override async Task<Prestamo?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Prestamo>> GetPrestamosConDetallesAsync()
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .ToListAsync();
    }

    public async Task<Prestamo?> GetPrestamoConDetallesAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Prestamo>> GetPrestamosActivosAsync()
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .Where(p => p.Estado == "Activo")
            .ToListAsync();
    }

    public async Task<IEnumerable<Prestamo>> GetHistorialPrestamosAsync(int usuarioId)
    {
        return await _dbSet
            .Include(p => p.Usuario)
            .Include(p => p.Libro)
            .Where(p => p.UsuarioId == usuarioId)
            .OrderByDescending(p => p.FechaPrestamo)
            .ToListAsync();
    }

    public async Task<int> CountPrestamosByUsuarioAsync(int usuarioId)
    {
        return await _dbSet.CountAsync(p => p.UsuarioId == usuarioId);
    }

    public async Task<int> CountPrestamosByLibroAsync(int libroId)
    {
        return await _dbSet.CountAsync(p => p.LibroId == libroId);
    }
}
