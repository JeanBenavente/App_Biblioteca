namespace App_Biblioteca.Application.DTOs.Libro;

public class CreateLibroDto
{
    public string Titulo { get; set; } = null!;

    public string ISBN { get; set; } = null!;

    public int? AnioPublicacion { get; set; }

    public int Stock { get; set; }

    public int AutorId { get; set; }

    public int CategoriaId { get; set; }

    public int EditorialId { get; set; }
}
