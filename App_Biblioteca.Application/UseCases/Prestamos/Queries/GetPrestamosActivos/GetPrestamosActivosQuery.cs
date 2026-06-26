using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamosActivos;

public class GetPrestamosActivosQuery : IRequest<IEnumerable<PrestamoResponseDto>>
{
}
