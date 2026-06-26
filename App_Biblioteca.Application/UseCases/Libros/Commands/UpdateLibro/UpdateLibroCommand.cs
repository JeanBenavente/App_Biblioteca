using MediatR;

namespace App_Biblioteca.Application.UseCases.Libros.Commands.UpdateLibro;

public class UpdateLibroCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? AnioPublicacion { get; set; }
    public int Stock { get; set; }
    public int AutorId { get; set; }
    public int CategoriaId { get; set; }
    public int EditorialId { get; set; }
}
