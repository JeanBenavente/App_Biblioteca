using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Autores.Queries.GetAutorById;

public class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, AutorResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAutorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AutorResponseDto> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        if (autor == null)
            throw new KeyNotFoundException($"Autor con Id {request.Id} no encontrado.");

        return new AutorResponseDto
        {
            Id = autor.Id,
            Nombre = autor.Nombre,
            Nacionalidad = autor.Nacionalidad,
            FechaNacimiento = autor.FechaNacimiento
        };
    }
}
