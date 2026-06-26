using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.BuscarLibroPorAutor;

public class BuscarLibroPorAutorQueryHandler : IRequestHandler<BuscarLibroPorAutorQuery, IEnumerable<LibroResponseDto>>
{
    private readonly ILibroRepository _libroRepository;

    public BuscarLibroPorAutorQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<IEnumerable<LibroResponseDto>> Handle(BuscarLibroPorAutorQuery request, CancellationToken cancellationToken)
    {
        var libros = await _libroRepository.BuscarPorAutorAsync(request.Autor);
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
