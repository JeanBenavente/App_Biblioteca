using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Editoriales.Queries.GetEditorialById;

public class GetEditorialByIdQueryHandler : IRequestHandler<GetEditorialByIdQuery, EditorialResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEditorialByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditorialResponseDto> Handle(GetEditorialByIdQuery request, CancellationToken cancellationToken)
    {
        var editorial = await _unitOfWork.Editoriales.GetByIdAsync(request.Id);
        if (editorial == null)
            throw new KeyNotFoundException($"Editorial con Id {request.Id} no encontrada.");

        return new EditorialResponseDto
        {
            Id = editorial.Id,
            Nombre = editorial.Nombre,
            Pais = editorial.Pais
        };
    }
}
