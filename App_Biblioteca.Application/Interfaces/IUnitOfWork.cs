using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Libro> Libros { get; }

    IRepository<Autor> Autores { get; }

    IRepository<Categoria> Categorias { get; }

    IRepository<Editorial> Editoriales { get; }

    IRepository<Usuario> Usuarios { get; }

    IRepository<Prestamo> Prestamos { get; }

    Task<int> SaveAsync();
}
