using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Application.Interfaces;

namespace App_Biblioteca.Application.UseCases.Libro;

public class GetLibroByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLibroByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LibroDto?> ExecuteAsync(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);

        return libro is null ? null : LibroMapper.ToDto(libro);
    }
}
