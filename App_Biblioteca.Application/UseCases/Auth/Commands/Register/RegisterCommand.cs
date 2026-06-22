using MediatR;
using App_Biblioteca.Domain.DTOs.Auth;

namespace App_Biblioteca.Application.UseCases.Auth.Commands.Register;

public class RegisterCommand : IRequest<LoginResponseDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
