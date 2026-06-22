using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.CreateAutor;

public class CreateAutorCommand : IRequest<AutorResponseDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string? Nacionalidad { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
}
