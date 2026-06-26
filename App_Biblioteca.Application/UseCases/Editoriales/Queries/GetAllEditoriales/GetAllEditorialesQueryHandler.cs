using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Editoriales.Queries.GetAllEditoriales;

public class GetAllEditorialesQueryHandler : IRequestHandler<GetAllEditorialesQuery, IEnumerable<EditorialResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEditorialesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EditorialResponseDto>> Handle(GetAllEditorialesQuery request, CancellationToken cancellationToken)
    {
        var editoriales = await _unitOfWork.Editoriales.GetAllAsync();
        return editoriales.Select(e => new EditorialResponseDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Pais = e.Pais
        });
    }
}
