using MediatR;

namespace App_Biblioteca.Application.UseCases.Libros.Commands.DeleteLibro;

public class DeleteLibroCommand : IRequest<bool>
{
    public int Id { get; set; }
}
