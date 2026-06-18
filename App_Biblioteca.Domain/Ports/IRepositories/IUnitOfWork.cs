namespace App_Biblioteca.Domain.Ports.IRepositories;

public interface IUnitOfWork
{
    IGenericRepository<Entities.Autor> Autores { get; }
    IGenericRepository<Entities.Categoria> Categorias { get; }
    IGenericRepository<Entities.Editorial> Editoriales { get; }
    IGenericRepository<Entities.Libro> Libros { get; }
    IGenericRepository<Entities.Prestamo> Prestamos { get; }
    IGenericRepository<Entities.Usuario> Usuarios { get; }
    IGenericRepository<Entities.Rol> Roles { get; }
    Task<int> SaveChangesAsync();
}
