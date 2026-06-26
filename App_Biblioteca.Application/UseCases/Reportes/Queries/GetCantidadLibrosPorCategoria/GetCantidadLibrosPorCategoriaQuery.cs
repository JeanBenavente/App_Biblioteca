using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorCategoria;

public class GetCantidadLibrosPorCategoriaQuery : IRequest<IEnumerable<CantidadDto>>
{
}
