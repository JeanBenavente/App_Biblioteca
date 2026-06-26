using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App_Biblioteca.Domain.DTOs.Auth;
using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Domain.Ports.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App_Biblioteca.Infrastructure.Adapters.Services;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var usuario = await _usuarioRepository.GetByCorreoAsync(request.Correo);
        if (usuario == null)
            throw new UnauthorizedAccessException("Credenciales inválidas.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            throw new UnauthorizedAccessException("Credenciales inválidas.");

        var token = GenerateToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Rol = usuario.Rol?.Nombre ?? "",
            Nombre = $"{usuario.Nombre} {usuario.Apellido}",
            Correo = usuario.Correo
        };
    }

    private string GenerateToken(Domain.Entities.Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Correo),
            new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"),
            new Claim(ClaimTypes.Role, usuario.Rol?.Nombre ?? "")
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(double.Parse(jwtSettings["ExpiresInHours"] ?? "8")),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
