using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.GetLibroById;

public class GetLibroByIdQueryHandler : IRequestHandler<GetLibroByIdQuery, LibroResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLibroByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LibroResponseDto> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        if (libro == null)
            throw new KeyNotFoundException($"Libro con Id {request.Id} no encontrado.");

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
