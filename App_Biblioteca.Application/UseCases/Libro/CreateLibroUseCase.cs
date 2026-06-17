using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Application.Interfaces;

namespace App_Biblioteca.Application.UseCases.Libro;

public class CreateLibroUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLibroUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<LibroDto> ExecuteAsync(CreateLibroDto dto)
    {
        var libro = LibroMapper.ToEntity(dto);

        await _unitOfWork.Libros.AddAsync(libro);
        await _unitOfWork.SaveAsync();

        return LibroMapper.ToDto(libro);
    }
}
