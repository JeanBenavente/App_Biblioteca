namespace App_Biblioteca.Domain.DTOs.Prestamo;

public class PrestamoResponseDto
{
    public int Id { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string Libro { get; set; } = string.Empty;
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public string Estado { get; set; } = string.Empty;
}
