using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;

namespace App_Biblioteca.Application.UseCases.Editoriales.Queries.GetEditorialById;

public class GetEditorialByIdQuery : IRequest<EditorialResponseDto>
{
    public int Id { get; set; }
}
