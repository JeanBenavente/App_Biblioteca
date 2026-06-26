using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;
using App_Biblioteca.Domain.Entities;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Prestamos.Commands.CreatePrestamo;

public class CreatePrestamoCommandHandler : IRequestHandler<CreatePrestamoCommand, PrestamoResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePrestamoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PrestamoResponseDto> Handle(CreatePrestamoCommand request, CancellationToken cancellationToken)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(request.LibroId);
        if (libro == null)
            throw new KeyNotFoundException($"Libro con Id {request.LibroId} no encontrado.");
        if (libro.Stock <= 0)
            throw new InvalidOperationException("No hay stock disponible para este libro.");

        libro.Stock--;

        var prestamo = new Prestamo
        {
            UsuarioId = request.UsuarioId,
            LibroId = request.LibroId,
            FechaPrestamo = DateTime.UtcNow,
            Estado = "Activo"
        };

        _unitOfWork.Libros.Update(libro);
        await _unitOfWork.Prestamos.AddAsync(prestamo);
        await _unitOfWork.SaveChangesAsync();

        return new PrestamoResponseDto
        {
            Id = prestamo.Id,
            Usuario = prestamo.Usuario?.Nombre ?? "",
            Libro = prestamo.Libro?.Titulo ?? "",
            FechaPrestamo = prestamo.FechaPrestamo,
            FechaDevolucion = prestamo.FechaDevolucion,
            Estado = prestamo.Estado
        };
    }
}
