using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Editoriales.Commands.DeleteEditorial;

public class DeleteEditorialCommandHandler : IRequestHandler<DeleteEditorialCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEditorialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEditorialCommand request, CancellationToken cancellationToken)
    {
        var editorial = await _unitOfWork.Editoriales.GetByIdAsync(request.Id);
        if (editorial == null)
            return false;

        _unitOfWork.Editoriales.Delete(editorial);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
