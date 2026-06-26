using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Commands.CreatePrestamo;

public class CreatePrestamoCommand : IRequest<PrestamoResponseDto>
{
    public int UsuarioId { get; set; }
    public int LibroId { get; set; }
}
