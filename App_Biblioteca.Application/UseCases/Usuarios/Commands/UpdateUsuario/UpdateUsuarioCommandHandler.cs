using MediatR;
using App_Biblioteca.Domain.DTOs.Usuario;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Usuarios.Commands.UpdateUsuario;

public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, UsuarioResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioResponseDto> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(request.Id);
        if (usuario == null)
            throw new KeyNotFoundException($"Usuario con Id {request.Id} no encontrado.");

        usuario.Nombre = request.Nombre;
        usuario.Apellido = request.Apellido;
        usuario.Correo = request.Correo;
        usuario.Telefono = request.Telefono;
        usuario.RolId = request.RolId;

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        }

        _unitOfWork.Usuarios.Update(usuario);
        await _unitOfWork.SaveChangesAsync();

        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Correo = usuario.Correo,
            Telefono = usuario.Telefono,
            FechaRegistro = usuario.FechaRegistro,
            Rol = usuario.Rol?.Nombre ?? ""
        };
    }
}
