using MediatR;
using App_Biblioteca.Domain.DTOs.Usuario;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Usuarios.Commands.CreateUsuario;

public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, UsuarioResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioResponseDto> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Correo = request.Correo,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Telefono = request.Telefono,
            FechaRegistro = DateTime.UtcNow,
            RolId = request.RolId
        };

        await _unitOfWork.Usuarios.AddAsync(usuario);
        await _unitOfWork.SaveChangesAsync();

        var usrCreado = await _unitOfWork.Usuarios.GetByIdAsync(usuario.Id);

        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Correo = usuario.Correo,
            Telefono = usuario.Telefono,
            FechaRegistro = usuario.FechaRegistro,
            Rol = usrCreado?.Rol?.Nombre ?? ""
        };
    }
}
