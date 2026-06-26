using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetTopUsuariosConMasPrestamos;

public class GetTopUsuariosConMasPrestamosQueryHandler : IRequestHandler<GetTopUsuariosConMasPrestamosQuery, IEnumerable<UsuarioPrestamoCountDto>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetTopUsuariosConMasPrestamosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioPrestamoCountDto>> Handle(GetTopUsuariosConMasPrestamosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioRepository.GetTopUsuariosConMasPrestamosAsync(request.Top);
        return usuarios.Select(u => new UsuarioPrestamoCountDto
        {
            UsuarioId = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Correo = u.Correo,
            TotalPrestamos = u.Prestamos?.Count ?? 0
        });
    }
}
