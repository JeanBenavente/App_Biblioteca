using System;
using System.Collections.Generic;

namespace App_Biblioteca.Structure.Persistence.Entities;

public partial class libros
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string ISBN { get; set; } = null!;

    public int? AnioPublicacion { get; set; }

    public int Stock { get; set; }

    public int AutorId { get; set; }

    public int CategoriaId { get; set; }

    public int EditorialId { get; set; }

    public virtual autores Autor { get; set; } = null!;

    public virtual categorias Categoria { get; set; } = null!;

    public virtual editoriales Editorial { get; set; } = null!;

    public virtual ICollection<prestamos> prestamos { get; set; } = new List<prestamos>();
}
