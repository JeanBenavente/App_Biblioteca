using System;
using System.Collections.Generic;

namespace App_Biblioteca.Structure.Persistence.Entities;

public partial class prestamos
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int LibroId { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual libros Libro { get; set; } = null!;

    public virtual usuarios Usuario { get; set; } = null!;
}
