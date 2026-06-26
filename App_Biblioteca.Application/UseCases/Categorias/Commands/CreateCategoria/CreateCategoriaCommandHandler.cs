using MediatR;
using App_Biblioteca.Domain.DTOs.Categoria;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.CreateCategoria;

public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CategoriaResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoriaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoriaResponseDto> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = new Categoria
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion
        };

        await _unitOfWork.Categorias.AddAsync(categoria);
        await _unitOfWork.SaveChangesAsync();

        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };
    }
}
