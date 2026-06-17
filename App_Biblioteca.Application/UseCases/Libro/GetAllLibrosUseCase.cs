using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Application.Interfaces;

namespace App_Biblioteca.Application.UseCases.Libro;

public class GetAllLibrosUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLibrosUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<LibroDto>> ExecuteAsync()
    {
        var libros = await _unitOfWork.Libros.GetAllAsync();

        return libros.Select(LibroMapper.ToDto);
    }
}
