using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;

namespace App_Biblioteca.Application.UseCases.Categorias.Queries.GetAllCategorias;

public class GetAllCategoriasQuery : IRequest<IEnumerable<CategoriaResponseDto>>
{
}
