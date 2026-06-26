using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.CreateCategoria;

public class CreateCategoriaCommand : IRequest<CategoriaResponseDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
}
