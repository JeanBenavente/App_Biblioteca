using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class EditorialRepository : GenericRepository<Editorial>, IEditorialRepository
{
    public EditorialRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Editorial>> GetEditorialesConLibrosAsync()
    {
        return await _dbSet.Include(e => e.Libros).ToListAsync();
    }
}
