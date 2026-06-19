using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _dbSet.Include(u => u.Rol).ToListAsync();
    }

    public override async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _dbSet.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Usuario?> GetByCorreoAsync(string correo)
    {
        return await _dbSet.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Correo == correo);
    }

    public async Task<IEnumerable<Usuario>> GetUsuariosConPrestamosActivosAsync()
    {
        return await _dbSet
            .Include(u => u.Rol)
            .Include(u => u.Prestamos)
            .Where(u => u.Prestamos.Any(p => p.Estado == "Activo"))
            .ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> GetTopUsuariosConMasPrestamosAsync(int top = 10)
    {
        return await _dbSet
            .Include(u => u.Rol)
            .Include(u => u.Prestamos)
            .OrderByDescending(u => u.Prestamos.Count)
            .Take(top)
            .ToListAsync();
    }
}
