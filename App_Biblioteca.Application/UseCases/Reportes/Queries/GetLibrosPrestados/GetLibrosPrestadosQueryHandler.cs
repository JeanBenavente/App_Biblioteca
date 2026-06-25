using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosPrestados;

public class GetLibrosPrestadosQueryHandler : IRequestHandler<GetLibrosPrestadosQuery, IEnumerable<LibroPrestadoDto>>
{
    private readonly IPrestamoRepository _prestamoRepository;

    public GetLibrosPrestadosQueryHandler(IPrestamoRepository prestamoRepository)
    {
        _prestamoRepository = prestamoRepository;
    }

    public async Task<IEnumerable<LibroPrestadoDto>> Handle(GetLibrosPrestadosQuery request, CancellationToken cancellationToken)
    {
        var prestamos = await _prestamoRepository.GetPrestamosActivosAsync();
        return prestamos.Select(p => new LibroPrestadoDto
        {
            Id = p.LibroId,
            Titulo = p.Libro?.Titulo ?? "",
            ISBN = p.Libro?.ISBN ?? "",
            Usuario = p.Usuario?.Nombre ?? "",
            FechaPrestamo = p.FechaPrestamo
        });
    }
}
