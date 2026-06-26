using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.UpdateAutor;

public class UpdateAutorCommand : IRequest<AutorResponseDto>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Nacionalidad { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
}
