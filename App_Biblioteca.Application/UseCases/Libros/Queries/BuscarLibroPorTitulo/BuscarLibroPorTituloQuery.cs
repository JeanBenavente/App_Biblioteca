using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.BuscarLibroPorTitulo;

public class BuscarLibroPorTituloQuery : IRequest<IEnumerable<LibroResponseDto>>
{
    public string Titulo { get; set; } = string.Empty;
}
