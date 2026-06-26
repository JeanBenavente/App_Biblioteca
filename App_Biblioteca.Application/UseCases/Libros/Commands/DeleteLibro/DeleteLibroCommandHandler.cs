using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Commands.DeleteLibro;

public class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLibroCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        if (libro == null)
            return false;

        _unitOfWork.Libros.Delete(libro);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
