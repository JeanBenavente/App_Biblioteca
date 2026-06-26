using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Commands.RegistrarDevolucion;

public class RegistrarDevolucionCommand : IRequest<PrestamoResponseDto>
{
    public int PrestamoId { get; set; }
}
