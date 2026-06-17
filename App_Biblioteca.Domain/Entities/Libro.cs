namespace App_Biblioteca.Domain.Entities;

public class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string ISBN { get; set; } = null!;

    public int? AnioPublicacion { get; set; }

    public int Stock { get; set; }

    public int AutorId { get; set; }

    public int CategoriaId { get; set; }

    public int EditorialId { get; set; }

    public Autor Autor { get; set; } = null!;

    public Categoria Categoria { get; set; } = null!;

    public Editorial Editorial { get; set; } = null!;

    public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
