namespace App_Biblioteca.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int RolId { get; set; }

    public Rol Rol { get; set; } = null!;

    public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
