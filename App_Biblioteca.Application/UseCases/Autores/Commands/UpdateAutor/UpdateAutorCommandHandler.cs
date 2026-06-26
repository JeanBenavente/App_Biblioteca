using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.UpdateAutor;

public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, AutorResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAutorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AutorResponseDto> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        if (autor == null)
            throw new KeyNotFoundException($"Autor con Id {request.Id} no encontrado.");

        autor.Nombre = request.Nombre;
        autor.Nacionalidad = request.Nacionalidad;
        autor.FechaNacimiento = request.FechaNacimiento;

        _unitOfWork.Autores.Update(autor);
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
