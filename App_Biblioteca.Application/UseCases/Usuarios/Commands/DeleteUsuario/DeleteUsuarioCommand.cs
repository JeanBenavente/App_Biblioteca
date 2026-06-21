using MediatR;

namespace App_Biblioteca.Application.UseCases.Usuarios.Commands.DeleteUsuario;

public class DeleteUsuarioCommand : IRequest<bool>
{
    public int Id { get; set; }
}
