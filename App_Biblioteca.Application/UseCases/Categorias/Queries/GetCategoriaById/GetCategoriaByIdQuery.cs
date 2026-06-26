using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;

namespace App_Biblioteca.Application.UseCases.Categorias.Queries.GetCategoriaById;

public class GetCategoriaByIdQuery : IRequest<CategoriaResponseDto>
{
    public int Id { get; set; }
}
