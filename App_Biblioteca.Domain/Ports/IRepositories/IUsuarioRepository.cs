using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario?> GetByCorreoAsync(string correo);
    Task<IEnumerable<Usuario>> GetUsuariosConPrestamosActivosAsync();
    Task<IEnumerable<Usuario>> GetTopUsuariosConMasPrestamosAsync(int top = 10);
}
