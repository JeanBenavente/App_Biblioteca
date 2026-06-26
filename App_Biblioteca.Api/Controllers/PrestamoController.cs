using App_Biblioteca.Application.UseCases.Prestamos.Commands.CreatePrestamo;
using App_Biblioteca.Application.UseCases.Prestamos.Commands.RegistrarDevolucion;
using App_Biblioteca.Application.UseCases.Prestamos.Queries.GetAllPrestamos;
using App_Biblioteca.Application.UseCases.Prestamos.Queries.GetHistorialPrestamos;
using App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamoById;
using App_Biblioteca.Application.UseCases.Prestamos.Queries.GetPrestamosActivos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PrestamoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrestamoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPrestamosQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetPrestamoByIdQuery { Id = id });
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("activos")]
    public async Task<IActionResult> GetActivos()
    {
        var result = await _mediator.Send(new GetPrestamosActivosQuery());
        return Ok(result);
    }

    [HttpGet("historial/{usuarioId}")]
    public async Task<IActionResult> GetHistorial(int usuarioId)
    {
        var result = await _mediator.Send(new GetHistorialPrestamosQuery { UsuarioId = usuarioId });
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador,Bibliotecario")]
    public async Task<IActionResult> Create([FromBody] CreatePrestamoCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("devolver/{prestamoId}")]
    [Authorize(Roles = "Administrador,Bibliotecario")]
    public async Task<IActionResult> RegistrarDevolucion(int prestamoId)
    {
        try
        {
            var result = await _mediator.Send(new RegistrarDevolucionCommand { PrestamoId = prestamoId });
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
