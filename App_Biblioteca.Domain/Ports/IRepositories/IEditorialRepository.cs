using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface IEditorialRepository : IGenericRepository<Editorial>
{
    Task<IEnumerable<Editorial>> GetEditorialesConLibrosAsync();
}
