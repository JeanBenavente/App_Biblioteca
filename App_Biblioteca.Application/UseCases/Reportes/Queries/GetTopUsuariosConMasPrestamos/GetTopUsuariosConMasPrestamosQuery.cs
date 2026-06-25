using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetTopUsuariosConMasPrestamos;

public class GetTopUsuariosConMasPrestamosQuery : IRequest<IEnumerable<UsuarioPrestamoCountDto>>
{
    public int Top { get; set; } = 10;
}
