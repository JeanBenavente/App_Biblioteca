using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.CreateEditorial;

public class CreateEditorialCommand : IRequest<EditorialResponseDto>
{
    public string Nombre { get; set; } = string.Empty;
    public string? Pais { get; set; }
}
