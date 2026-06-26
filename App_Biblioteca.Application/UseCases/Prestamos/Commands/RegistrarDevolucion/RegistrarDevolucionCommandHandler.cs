using MediatR;
using App_Biblioteca.Domain.DTOs.Prestamo;
using App_Biblioteca.Domain.Ports.IRepositories;

namespace App_Biblioteca.Application.UseCases.Prestamos.Commands.RegistrarDevolucion;

public class RegistrarDevolucionCommandHandler : IRequestHandler<RegistrarDevolucionCommand, PrestamoResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarDevolucionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PrestamoResponseDto> Handle(RegistrarDevolucionCommand request, CancellationToken cancellationToken)
    {
        var prestamo = await _unitOfWork.Prestamos.GetByIdAsync(request.PrestamoId);
        if (prestamo == null)
            throw new KeyNotFoundException($"Préstamo con Id {request.PrestamoId} no encontrado.");

        if (prestamo.Estado == "Devuelto")
            throw new InvalidOperationException("Este préstamo ya fue devuelto.");

        prestamo.Estado = "Devuelto";
        prestamo.FechaDevolucion = DateTime.UtcNow;

        var libro = await _unitOfWork.Libros.GetByIdAsync(prestamo.LibroId);
        if (libro != null)
        {
            libro.Stock++;
            _unitOfWork.Libros.Update(libro);
        }

        _unitOfWork.Prestamos.Update(prestamo);
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
