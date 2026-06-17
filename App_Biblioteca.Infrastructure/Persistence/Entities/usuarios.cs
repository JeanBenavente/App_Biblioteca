using System;
using System.Collections.Generic;

namespace App_Biblioteca.Structure.Persistence.Entities;

public partial class usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int RolId { get; set; }

    public virtual roles Rol { get; set; } = null!;

    public virtual ICollection<prestamos> prestamos { get; set; } = new List<prestamos>();
}
