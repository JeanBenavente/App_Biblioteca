using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Autores.Commands.DeleteAutor;

public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAutorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(request.Id);
        if (autor == null)
            return false;

        _unitOfWork.Autores.Delete(autor);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
