using MediatR;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.DeleteCategoria;

public class DeleteCategoriaCommand : IRequest<bool>
{
    public int Id { get; set; }
}
