using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_Biblioteca.Infrastructure.Adapters.Repositories;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(BibliotecaDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasConLibrosAsync()
    {
        return await _dbSet.Include(c => c.Libros).ToListAsync();
    }
}
