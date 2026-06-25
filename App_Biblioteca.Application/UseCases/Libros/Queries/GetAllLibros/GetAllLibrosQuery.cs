using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.GetAllLibros;

public class GetAllLibrosQuery : IRequest<IEnumerable<LibroResponseDto>>
{
}
