using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.UpdateCategoria;

public class UpdateCategoriaCommand : IRequest<CategoriaResponseDto>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}
