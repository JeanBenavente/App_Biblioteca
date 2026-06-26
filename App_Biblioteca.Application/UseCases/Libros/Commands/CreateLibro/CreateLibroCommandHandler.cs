using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Commands.CreateLibro;

public class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, LibroResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLibroCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LibroResponseDto> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = new Libro
        {
            Titulo = request.Titulo,
            ISBN = request.ISBN,
            AnioPublicacion = request.AnioPublicacion,
            Stock = request.Stock,
            AutorId = request.AutorId,
            CategoriaId = request.CategoriaId,
            EditorialId = request.EditorialId
        };

        await _unitOfWork.Libros.AddAsync(libro);
        await _unitOfWork.SaveChangesAsync();

        return new LibroResponseDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            ISBN = libro.ISBN,
            AnioPublicacion = libro.AnioPublicacion,
            Stock = libro.Stock,
            Autor = libro.Autor?.Nombre ?? "",
            Categoria = libro.Categoria?.Nombre ?? "",
            Editorial = libro.Editorial?.Nombre ?? ""
        };
    }
}
