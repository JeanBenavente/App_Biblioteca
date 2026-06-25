using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorCategoria;

public class GetCantidadLibrosPorCategoriaQueryHandler : IRequestHandler<GetCantidadLibrosPorCategoriaQuery, IEnumerable<CantidadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCantidadLibrosPorCategoriaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CantidadDto>> Handle(GetCantidadLibrosPorCategoriaQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.GetAllAsync();
        return libros
            .GroupBy(l => l.Categoria!.Nombre)
            .Select(g => new CantidadDto
            {
                Nombre = g.Key,
                Cantidad = g.Count()
            })
            .OrderByDescending(x => x.Cantidad);
    }
}
