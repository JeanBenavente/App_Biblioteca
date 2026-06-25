using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.GetLibroById;

public class GetLibroByIdQuery : IRequest<LibroResponseDto>
{
    public int Id { get; set; }
}
