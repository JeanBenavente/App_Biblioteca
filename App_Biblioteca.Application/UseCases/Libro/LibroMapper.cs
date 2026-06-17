using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Application.UseCases.Libro;

internal static class LibroMapper
{
    public static LibroDto ToDto(Domain.Entities.Libro libro)
    {
        return new LibroDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            ISBN = libro.ISBN,
            AnioPublicacion = libro.AnioPublicacion,
            Stock = libro.Stock,
            AutorId = libro.AutorId,
            CategoriaId = libro.CategoriaId,
            EditorialId = libro.EditorialId
        };
    }

    public static Domain.Entities.Libro ToEntity(CreateLibroDto dto)
    {
        return new Domain.Entities.Libro
        {
            Titulo = dto.Titulo,
            ISBN = dto.ISBN,
            AnioPublicacion = dto.AnioPublicacion,
            Stock = dto.Stock,
            AutorId = dto.AutorId,
            CategoriaId = dto.CategoriaId,
            EditorialId = dto.EditorialId
        };
    }

    public static void UpdateEntity(Domain.Entities.Libro libro, UpdateLibroDto dto)
    {
        libro.Titulo = dto.Titulo;
        libro.ISBN = dto.ISBN;
        libro.AnioPublicacion = dto.AnioPublicacion;
        libro.Stock = dto.Stock;
        libro.AutorId = dto.AutorId;
        libro.CategoriaId = dto.CategoriaId;
        libro.EditorialId = dto.EditorialId;
    }
}
