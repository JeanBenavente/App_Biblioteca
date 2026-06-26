using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamoById;

public class GetPrestamoByIdQueryHandler : IRequestHandler<GetPrestamoByIdQuery, PrestamoResponseDto>
{
    private readonly IPrestamoRepository _prestamoRepository;

    public GetPrestamoByIdQueryHandler(IPrestamoRepository prestamoRepository)
    {
        _prestamoRepository = prestamoRepository;
    }

    public async Task<PrestamoResponseDto> Handle(GetPrestamoByIdQuery request, CancellationToken cancellationToken)
    {
        var prestamo = await _prestamoRepository.GetPrestamoConDetallesAsync(request.Id);
        if (prestamo == null)
            throw new KeyNotFoundException($"Préstamo con Id {request.Id} no encontrado.");

        return new PrestamoResponseDto
        {
            Id = prestamo.Id,
            Usuario = prestamo.Usuario?.Nombre ?? "",
            Libro = prestamo.Libro?.Titulo ?? "",
            FechaPrestamo = prestamo.FechaPrestamo,
            FechaDevolucion = prestamo.FechaDevolucion,
            Estado = prestamo.Estado
        };
    }
}
