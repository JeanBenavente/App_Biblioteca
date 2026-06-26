using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Categorias.Commands.DeleteCategoria;

public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoriaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(request.Id);
        if (categoria == null)
            return false;

        _unitOfWork.Categorias.Delete(categoria);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
