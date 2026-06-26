using MediatR;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.DeleteEditorial;

public class DeleteEditorialCommand : IRequest<bool>
{
    public int Id { get; set; }
}
