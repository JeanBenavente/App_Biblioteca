namespace App_Biblioteca.Domain.DTOs.Usuario;

public class UsuarioRequestDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public int RolId { get; set; }
}
