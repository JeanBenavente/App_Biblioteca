namespace App_Biblioteca.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
