using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class AutorRepository : GenericRepository<Autor>, IAutorRepository
{
    public AutorRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Autor>> GetAutoresConLibrosAsync()
    {
        return await _dbSet.Include(a => a.Libros).ToListAsync();
    }
}
