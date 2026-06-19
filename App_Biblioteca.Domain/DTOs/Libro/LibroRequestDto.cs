namespace App_Biblioteca.Domain.DTOs.Libro;

public class LibroRequestDto
{
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? AnioPublicacion { get; set; }
    public int Stock { get; set; }
    public int AutorId { get; set; }
    public int CategoriaId { get; set; }
    public int EditorialId { get; set; }
}
