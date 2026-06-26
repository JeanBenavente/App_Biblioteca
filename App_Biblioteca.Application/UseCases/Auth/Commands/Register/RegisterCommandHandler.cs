using MediatR;
using App_Biblioteca.Domain.DTOs.Auth;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Domain.Ports.IServices;

namespace App_Biblioteca.Application.UseCases.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<LoginResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existe = await _unitOfWork.Usuarios.AnyAsync(u => u.Correo == request.Correo);
        if (existe)
            throw new InvalidOperationException("El correo ya está registrado.");

        var rolBibliotecario = await _unitOfWork.Roles.FindAsync(r => r.Nombre == "Bibliotecario");
        var rol = rolBibliotecario.FirstOrDefault() ?? new Rol { Nombre = "Bibliotecario" };

        var usuario = new Usuario
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Correo = request.Correo,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            FechaRegistro = DateTime.UtcNow,
            RolId = rol.Id
        };

        await _unitOfWork.Usuarios.AddAsync(usuario);
        await _unitOfWork.SaveChangesAsync();

        var loginRequest = new LoginRequestDto
        {
            Correo = request.Correo,
            Password = request.Password
        };

        return await _authService.LoginAsync(loginRequest);
    }
}
