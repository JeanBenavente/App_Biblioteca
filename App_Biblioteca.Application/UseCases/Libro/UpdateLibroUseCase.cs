using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Application.Interfaces;

namespace App_Biblioteca.Application.UseCases.Libro;

public class UpdateLibroUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLibroUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ExecuteAsync(int id, UpdateLibroDto dto)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);

        if (libro is null)
        {
            return false;
        }

        LibroMapper.UpdateEntity(libro, dto);
        _unitOfWork.Libros.Update(libro);
        await _unitOfWork.SaveAsync();

        return true;
    }
}
