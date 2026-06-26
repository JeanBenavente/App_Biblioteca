using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Autores.Queries.GetAllAutores;

public class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAutoresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AutorResponseDto>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
    {
        var autores = await _unitOfWork.Autores.GetAllAsync();
        return autores.Select(a => new AutorResponseDto
        {
            Id = a.Id,
            Nombre = a.Nombre,
            Nacionalidad = a.Nacionalidad,
            FechaNacimiento = a.FechaNacimiento
        });
    }
}
