using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.GetAllLibros;

public class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, IEnumerable<LibroResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLibrosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<LibroResponseDto>> Handle(GetAllLibrosQuery request, CancellationToken cancellationToken)
    {
        var libros = await _unitOfWork.Libros.GetAllAsync();
        return libros.Select(l => new LibroResponseDto
        {
            Id = l.Id,
            Titulo = l.Titulo,
            ISBN = l.ISBN,
            AnioPublicacion = l.AnioPublicacion,
            Stock = l.Stock,
            Autor = l.Autor?.Nombre ?? "",
            Categoria = l.Categoria?.Nombre ?? "",
            Editorial = l.Editorial?.Nombre ?? ""
        });
    }
}
