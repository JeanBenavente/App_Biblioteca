namespace App_Biblioteca.Domain.DTOs.Libro;

public class LibroResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? AnioPublicacion { get; set; }
    public int Stock { get; set; }
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Editorial { get; set; } = string.Empty;
}
