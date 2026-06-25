using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.ObtenerLibrosDisponibles;

public class ObtenerLibrosDisponiblesQuery : IRequest<IEnumerable<LibroResponseDto>>
{
}
