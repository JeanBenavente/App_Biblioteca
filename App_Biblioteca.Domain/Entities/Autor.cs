namespace App_Biblioteca.Domain.Entities;

public class Autor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Nacionalidad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
