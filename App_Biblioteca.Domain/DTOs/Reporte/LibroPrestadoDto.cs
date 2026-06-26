namespace App_Biblioteca.Domain.DTOs.Reporte;

public class LibroPrestadoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public DateTime FechaPrestamo { get; set; }
}
