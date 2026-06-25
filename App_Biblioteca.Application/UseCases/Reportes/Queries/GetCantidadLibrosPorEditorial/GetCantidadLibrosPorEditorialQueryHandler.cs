using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorEditorial;

public class GetCantidadLibrosPorEditorialQueryHandler : IRequestHandler<GetCantidadLibrosPorEditorialQuery, IEnumerable<CantidadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCantidadLibrosPorEditorialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CantidadDto>> Handle(GetCantidadLibrosPorEditorialQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.GetAllAsync();
        return libros
            .GroupBy(l => l.Editorial!.Nombre)
            .Select(g => new CantidadDto
            {
                Nombre = g.Key,
                Cantidad = g.Count()
            })
            .OrderByDescending(x => x.Cantidad);
    }
}
