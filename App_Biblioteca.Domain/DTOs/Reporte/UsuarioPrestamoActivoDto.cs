namespace App_Biblioteca.Domain.DTOs.Reporte;

public class UsuarioPrestamoActivoDto
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public int CantidadPrestamosActivos { get; set; }
}
