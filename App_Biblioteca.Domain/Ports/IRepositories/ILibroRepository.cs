using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface ILibroRepository : IGenericRepository<Libro>
{
    Task<IEnumerable<Libro>> GetLibrosConDetallesAsync();
    Task<Libro?> GetLibroConDetallesAsync(int id);
    Task<IEnumerable<Libro>> BuscarPorTituloAsync(string titulo);
    Task<IEnumerable<Libro>> BuscarPorAutorAsync(string autor);
    Task<IEnumerable<Libro>> BuscarPorCategoriaAsync(string categoria);
    Task<IEnumerable<Libro>> ObtenerDisponiblesAsync();
    Task<IEnumerable<Libro>> GetTopLibrosMasPrestadosAsync(int top = 10);
}
