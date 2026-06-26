using App_Biblioteca.Domain.DTOs.Auth;

namespace App_Biblioteca.Domain.Ports.IServices;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}
