using MediatR;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Libros.Commands.UpdateLibro;

public class UpdateLibroCommandHandler : IRequestHandler<UpdateLibroCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLibroCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.Id);
        if (libro == null)
            return false;

        libro.Titulo = request.Titulo;
        libro.ISBN = request.ISBN;
        libro.AnioPublicacion = request.AnioPublicacion;
        libro.Stock = request.Stock;
        libro.AutorId = request.AutorId;
        libro.CategoriaId = request.CategoriaId;
        libro.EditorialId = request.EditorialId;

        _unitOfWork.Libros.Update(libro);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
