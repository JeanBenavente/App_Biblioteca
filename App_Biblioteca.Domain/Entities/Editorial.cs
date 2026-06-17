namespace App_Biblioteca.Domain.Entities;

public class Editorial
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Pais { get; set; }

    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
