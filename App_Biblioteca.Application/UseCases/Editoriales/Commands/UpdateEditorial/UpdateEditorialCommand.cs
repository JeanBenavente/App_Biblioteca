using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.UpdateEditorial;

public class UpdateEditorialCommand : IRequest<EditorialResponseDto>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Pais { get; set; }
}
