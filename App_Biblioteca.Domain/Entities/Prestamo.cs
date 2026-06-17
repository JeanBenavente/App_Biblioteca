namespace App_Biblioteca.Domain.Entities;

public class Prestamo
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int LibroId { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string Estado { get; set; } = null!;

    public Libro Libro { get; set; } = null!;

    public Usuario Usuario { get; set; } = null!;
}
