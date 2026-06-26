using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.BuscarLibroPorCategoria;

public class BuscarLibroPorCategoriaQuery : IRequest<IEnumerable<LibroResponseDto>>
{
    public string Categoria { get; set; } = string.Empty;
}
