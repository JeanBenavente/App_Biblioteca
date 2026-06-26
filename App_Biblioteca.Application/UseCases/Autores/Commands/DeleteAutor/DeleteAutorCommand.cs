using MediatR;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.DeleteAutor;

public class DeleteAutorCommand : IRequest<bool>
{
    public int Id { get; set; }
}
