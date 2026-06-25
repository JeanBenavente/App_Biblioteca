using MediatR;
using App_Biblioteca.Domain.DTOs.Reporte;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosDisponibles;

public class GetLibrosDisponiblesQueryHandler : IRequestHandler<GetLibrosDisponiblesQuery, IEnumerable<LibroDisponibleDto>>
{
    private readonly ILibroRepository _libroRepository;

    public GetLibrosDisponiblesQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<IEnumerable<LibroDisponibleDto>> Handle(GetLibrosDisponiblesQuery request, CancellationToken cancellationToken)
    {
        var libros = await _libroRepository.ObtenerDisponiblesAsync();
        return libros.Select(l => new LibroDisponibleDto
        {
            Id = l.Id,
            Titulo = l.Titulo,
            ISBN = l.ISBN,
            Stock = l.Stock,
            Autor = l.Autor?.Nombre ?? "",
            Categoria = l.Categoria?.Nombre ?? ""
        });
    }
}
