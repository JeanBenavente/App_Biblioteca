using System;
using System.Collections.Generic;

namespace App_Biblioteca.Structure.Persistence.Entities;

public partial class editoriales
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Pais { get; set; }

    public virtual ICollection<libros> libros { get; set; } = new List<libros>();
}
