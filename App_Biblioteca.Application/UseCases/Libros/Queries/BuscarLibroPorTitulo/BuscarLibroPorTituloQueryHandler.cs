using MediatR;
using App_Biblioteca.Domain.DTOs.Libro;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Queries.BuscarLibroPorTitulo;

public class BuscarLibroPorTituloQueryHandler : IRequestHandler<BuscarLibroPorTituloQuery, IEnumerable<LibroResponseDto>>
{
    private readonly ILibroRepository _libroRepository;

    public BuscarLibroPorTituloQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<IEnumerable<LibroResponseDto>> Handle(BuscarLibroPorTituloQuery request, CancellationToken cancellationToken)
    {
        var libros = await _libroRepository.BuscarPorTituloAsync(request.Titulo);
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
