using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetHistorialPrestamos;

public class GetHistorialPrestamosQuery : IRequest<IEnumerable<PrestamoResponseDto>>
{
    public int UsuarioId { get; set; }
}
