using System;
using System.Collections.Generic;

namespace App_Biblioteca.Structure.Persistence.Entities;

public partial class roles
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<usuarios> usuarios { get; set; } = new List<usuarios>();
}
