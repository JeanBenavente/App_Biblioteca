using MediatR;
using App_Biblioteca.Domain.DTOs.Auth;
using App_Biblioteca.Domain.Ports.IServices;

namespace App_Biblioteca.Application.UseCases.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginRequest = new LoginRequestDto
        {
            Correo = request.Correo,
            Password = request.Password
        };

        return await _authService.LoginAsync(loginRequest);
    }
}
