using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosPrestados;

public class GetLibrosPrestadosQuery : IRequest<IEnumerable<LibroPrestadoDto>>
{
}
