using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface IPrestamoRepository : IGenericRepository<Prestamo>
{
    Task<IEnumerable<Prestamo>> GetPrestamosConDetallesAsync();
    Task<Prestamo?> GetPrestamoConDetallesAsync(int id);
    Task<IEnumerable<Prestamo>> GetPrestamosActivosAsync();
    Task<IEnumerable<Prestamo>> GetHistorialPrestamosAsync(int usuarioId);
    Task<int> CountPrestamosByUsuarioAsync(int usuarioId);
    Task<int> CountPrestamosByLibroAsync(int libroId);
}
