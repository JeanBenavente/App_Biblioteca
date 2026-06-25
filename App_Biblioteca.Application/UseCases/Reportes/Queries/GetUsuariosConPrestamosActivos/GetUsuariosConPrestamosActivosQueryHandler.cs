using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetUsuariosConPrestamosActivos;

public class GetUsuariosConPrestamosActivosQueryHandler : IRequestHandler<GetUsuariosConPrestamosActivosQuery, IEnumerable<UsuarioPrestamoActivoDto>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuariosConPrestamosActivosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioPrestamoActivoDto>> Handle(GetUsuariosConPrestamosActivosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioRepository.GetUsuariosConPrestamosActivosAsync();
        return usuarios.Select(u => new UsuarioPrestamoActivoDto
        {
            UsuarioId = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            Correo = u.Correo,
            CantidadPrestamosActivos = u.Prestamos?.Count(p => p.Estado == "Activo") ?? 0
        });
    }
}
