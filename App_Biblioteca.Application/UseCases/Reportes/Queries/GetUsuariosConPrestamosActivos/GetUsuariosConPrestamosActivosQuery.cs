using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetUsuariosConPrestamosActivos;

public class GetUsuariosConPrestamosActivosQuery : IRequest<IEnumerable<UsuarioPrestamoActivoDto>>
{
}
