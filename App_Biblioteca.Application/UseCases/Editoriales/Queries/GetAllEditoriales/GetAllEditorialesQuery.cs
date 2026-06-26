using MediatR;
using App_Biblioteca.Domain.DTOs.Editorial;

namespace App_Biblioteca.Application.UseCases.Editoriales.Queries.GetAllEditoriales;

public class GetAllEditorialesQuery : IRequest<IEnumerable<EditorialResponseDto>>
{
}
