using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.CreateAutor;

public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, AutorResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAutorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AutorResponseDto> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = new Autor
        {
            Nombre = request.Nombre,
            Nacionalidad = request.Nacionalidad,
            FechaNacimiento = request.FechaNacimiento
        };

        await _unitOfWork.Autores.AddAsync(autor);
        await _unitOfWork.SaveChangesAsync();

        return new AutorResponseDto
        {
            Id = autor.Id,
            Nombre = autor.Nombre,
            Nacionalidad = autor.Nacionalidad,
            FechaNacimiento = autor.FechaNacimiento
        };
    }
}
