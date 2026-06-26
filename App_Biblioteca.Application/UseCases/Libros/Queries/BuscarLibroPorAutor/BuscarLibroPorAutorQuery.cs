using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.BuscarLibroPorAutor;

public class BuscarLibroPorAutorQuery : IRequest<IEnumerable<LibroResponseDto>>
{
    public string Autor { get; set; } = string.Empty;
}
