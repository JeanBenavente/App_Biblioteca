using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Categorias.Queries.GetCategoriaById;

public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoriaResponseDto> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(request.Id);
        if (categoria == null)
            throw new KeyNotFoundException($"Categoria con Id {request.Id} no encontrada.");

        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
    }
}
