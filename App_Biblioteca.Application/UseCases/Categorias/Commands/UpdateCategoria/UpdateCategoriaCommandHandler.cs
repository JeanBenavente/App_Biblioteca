using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.UpdateCategoria;

public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, CategoriaResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoriaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoriaResponseDto> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(request.Id);
        if (categoria == null)
            throw new KeyNotFoundException($"Categoria con Id {request.Id} no encontrada.");

        categoria.Nombre = request.Nombre;
        categoria.Descripcion = request.Descripcion;

        _unitOfWork.Categorias.Update(categoria);
        await _unitOfWork.SaveChangesAsync();

        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
    }
}
