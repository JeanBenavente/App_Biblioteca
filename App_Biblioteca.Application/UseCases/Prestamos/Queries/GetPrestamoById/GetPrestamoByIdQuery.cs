using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamoById;

public class GetPrestamoByIdQuery : IRequest<PrestamoResponseDto>
{
    public int Id { get; set; }
}
