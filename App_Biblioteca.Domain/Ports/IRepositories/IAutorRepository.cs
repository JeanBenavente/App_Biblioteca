using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface IAutorRepository : IGenericRepository<Autor>
{
    Task<IEnumerable<Autor>> GetAutoresConLibrosAsync();
}
