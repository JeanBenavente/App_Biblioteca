using App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorCategoria;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadLibrosPorEditorial;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetCantidadPrestamosPorUsuario;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosDisponibles;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetLibrosPrestados;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetTopLibrosMasPrestados;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetTopUsuariosConMasPrestamos;
using App_Biblioteca.Application.UseCases.Reportes.Queries.GetUsuariosConPrestamosActivos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class ReporteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReporteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("libros-disponibles")]
    public async Task<IActionResult> GetLibrosDisponibles()
    {
        var result = await _mediator.Send(new GetLibrosDisponiblesQuery());
        return Ok(result);
    }

    [HttpGet("libros-prestados")]
    public async Task<IActionResult> GetLibrosPrestados()
    {
        var result = await _mediator.Send(new GetLibrosPrestadosQuery());
        return Ok(result);
    }

    [HttpGet("usuarios-prestamos-activos")]
    public async Task<IActionResult> GetUsuariosConPrestamosActivos()
    {
        var result = await _mediator.Send(new GetUsuariosConPrestamosActivosQuery());
        return Ok(result);
    }

    [HttpGet("top-libros")]
    public async Task<IActionResult> GetTopLibrosMasPrestados([FromQuery] int top = 10)
    {
        var result = await _mediator.Send(new GetTopLibrosMasPrestadosQuery { Top = top });
        return Ok(result);
    }

    [HttpGet("top-usuarios")]
    public async Task<IActionResult> GetTopUsuariosConMasPrestamos([FromQuery] int top = 10)
    {
        var result = await _mediator.Send(new GetTopUsuariosConMasPrestamosQuery { Top = top });
        return Ok(result);
    }

    [HttpGet("cantidad-libros-por-categoria")]
    public async Task<IActionResult> GetCantidadLibrosPorCategoria()
    {
        var result = await _mediator.Send(new GetCantidadLibrosPorCategoriaQuery());
        return Ok(result);
    }

    [HttpGet("cantidad-libros-por-editorial")]
    public async Task<IActionResult> GetCantidadLibrosPorEditorial()
    {
        var result = await _mediator.Send(new GetCantidadLibrosPorEditorialQuery());
        return Ok(result);
    }

    [HttpGet("cantidad-prestamos-por-usuario")]
    public async Task<IActionResult> GetCantidadPrestamosPorUsuario()
    {
        var result = await _mediator.Send(new GetCantidadPrestamosPorUsuarioQuery());
        return Ok(result);
    }
}
