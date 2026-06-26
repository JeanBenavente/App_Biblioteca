using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorEditorial;

public class GetCantidadLibrosPorEditorialQuery : IRequest<IEnumerable<CantidadDto>>
{
}
