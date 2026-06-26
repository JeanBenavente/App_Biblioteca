namespace App_Biblioteca.Domain.DTOs.Libro;

public class LibroResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? AnioPublicacion { get; set; }
    public int Stock { get; set; }
    public string? Autor { get; set; }
    public string? Categoria { get; set; }
    public string? Editorial { get; set; }
}
