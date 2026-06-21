namespace App_Biblioteca.Domain.DTOs.Reporte;

public class LibroDisponibleDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
}
