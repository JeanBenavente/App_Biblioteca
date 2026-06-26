using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetTopLibrosMasPrestados;

public class GetTopLibrosMasPrestadosQuery : IRequest<IEnumerable<LibroResponseDto>>
{
    public int Top { get; set; } = 10;
}
