using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.UpdateEditorial;

public class UpdateEditorialCommandHandler : IRequestHandler<UpdateEditorialCommand, EditorialResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEditorialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EditorialResponseDto> Handle(UpdateEditorialCommand request, CancellationToken cancellationToken)
    {
        var editorial = await _unitOfWork.Editoriales.GetByIdAsync(request.Id);
        if (editorial == null)
            throw new KeyNotFoundException($"Editorial con Id {request.Id} no encontrada.");

        editorial.Nombre = request.Nombre;
        editorial.Pais = request.Pais;

        _unitOfWork.Editoriales.Update(editorial);
        await _unitOfWork.SaveChangesAsync();

        return new EditorialResponseDto
        {
            Id = editorial.Id,
            Nombre = editorial.Nombre,
            Pais = editorial.Pais
        };
    }
}
