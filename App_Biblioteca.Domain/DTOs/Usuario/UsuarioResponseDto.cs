namespace App_Biblioteca.Domain.DTOs.Usuario;

public class UsuarioResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Rol { get; set; } = string.Empty;
}
