using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadPrestamosPorUsuario;

public class GetCantidadPrestamosPorUsuarioQuery : IRequest<IEnumerable<CantidadDto>>
{
}
