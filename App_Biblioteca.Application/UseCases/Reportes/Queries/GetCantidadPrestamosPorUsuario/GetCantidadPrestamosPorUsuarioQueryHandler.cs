using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadPrestamosPorUsuario;

public class GetCantidadPrestamosPorUsuarioQueryHandler : IRequestHandler<GetCantidadPrestamosPorUsuarioQuery, IEnumerable<CantidadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCantidadPrestamosPorUsuarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CantidadDto>> Handle(GetCantidadPrestamosPorUsuarioQuery request, CancellationToken cancellationToken)
    {
        var prestamos = await _unitOfWork.Prestamos.GetAllAsync();
        var usuarios = await _unitOfWork.Usuarios.GetAllAsync();

        return prestamos
            .GroupBy(p => p.UsuarioId)
            .Select(g => new
            {
                UsuarioId = g.Key,
                Total = g.Count()
            })
            .OrderByDescending(x => x.Total)
            .Select(x =>
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == x.UsuarioId);
                return new CantidadDto
                {
                    Nombre = usuario != null ? $"{usuario.Nombre} {usuario.Apellido}" : "Desconocido",
                    Cantidad = x.Total
                };
            });
    }
}
