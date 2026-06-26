using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetAllPrestamos;

public class GetAllPrestamosQuery : IRequest<IEnumerable<PrestamoResponseDto>>
{
}
