using MediatR;
using App_Biblioteca.Domain.DTOs.Usuario;

namespace App_Biblioteca.Application.UseCases.Usuarios.Commands.CreateUsuario;

public class CreateUsuarioCommand : IRequest<UsuarioResponseDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public int RolId { get; set; }
}
