using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Usuarios.Commands.DeleteUsuario;

public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(request.Id);
        if (usuario == null)
            return false;

        _unitOfWork.Usuarios.Delete(usuario);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
