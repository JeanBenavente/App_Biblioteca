using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface ICategoriaRepository : IGenericRepository<Categoria>
{
    Task<IEnumerable<Categoria>> GetCategoriasConLibrosAsync();
}
