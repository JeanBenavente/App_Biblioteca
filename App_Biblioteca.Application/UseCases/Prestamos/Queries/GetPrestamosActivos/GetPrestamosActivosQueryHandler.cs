using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamosActivos;

public class GetPrestamosActivosQueryHandler : IRequestHandler<GetPrestamosActivosQuery, IEnumerable<PrestamoResponseDto>>
{
    private readonly IPrestamoRepository _prestamoRepository;

    public GetPrestamosActivosQueryHandler(IPrestamoRepository prestamoRepository)
    {
        _prestamoRepository = prestamoRepository;
    }

    public async Task<IEnumerable<PrestamoResponseDto>> Handle(GetPrestamosActivosQuery request, CancellationToken cancellationToken)
    {
        var prestamos = await _prestamoRepository.GetPrestamosActivosAsync();
        return prestamos.Select(p => new PrestamoResponseDto
        {
            Id = p.Id,
            Usuario = p.Usuario?.Nombre ?? "",
            Libro = p.Libro?.Titulo ?? "",
            FechaPrestamo = p.FechaPrestamo,
            FechaDevolucion = p.FechaDevolucion,
            Estado = p.Estado
        });
    }
}
