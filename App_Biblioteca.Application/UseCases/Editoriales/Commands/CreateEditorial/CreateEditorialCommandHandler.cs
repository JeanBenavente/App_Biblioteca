using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.CreateEditorial;

public class CreateEditorialCommandHandler : IRequestHandler<CreateEditorialCommand, EditorialResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEditorialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditorialResponseDto> Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
    {
        var editorial = new Editorial
        {
            Nombre = request.Nombre,
            Pais = request.Pais
        };

        await _unitOfWork.Editoriales.AddAsync(editorial);
        await _unitOfWork.SaveChangesAsync();

        return new EditorialResponseDto
        {
            Id = editorial.Id,
            Nombre = editorial.Nombre,
            Pais = editorial.Pais
        };
    }
}
