using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosDisponibles;

public class GetLibrosDisponiblesQuery : IRequest<IEnumerable<LibroDisponibleDto>>
{
}
