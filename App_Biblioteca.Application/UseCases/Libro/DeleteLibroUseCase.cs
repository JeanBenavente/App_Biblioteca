using App_Biblioteca.Application.Interfaces;

namespace App_Biblioteca.Application.UseCases.Libro;

public class DeleteLibroUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLibroUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);

        if (libro is null)
        {
            return false;
        }

        _unitOfWork.Libros.Delete(libro);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
