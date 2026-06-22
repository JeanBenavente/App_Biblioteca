using MediatR;
using App_Biblioteca.Domain.DTOs.Auth;

namespace App_Biblioteca.Application.UseCases.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponseDto>
{
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
