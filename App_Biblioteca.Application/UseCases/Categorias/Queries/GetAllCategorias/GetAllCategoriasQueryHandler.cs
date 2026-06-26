using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Categorias.Queries.GetAllCategorias;

public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, IEnumerable<CategoriaResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoriasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoriaResponseDto>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        return categorias.Select(c => new CategoriaResponseDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion
        });
    }
}
