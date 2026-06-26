using App_Biblioteca.Application.UseCases.Libros.Commands.CreateLibro;
using App_Biblioteca.Application.UseCases.Libros.Commands.DeleteLibro;
using App_Biblioteca.Application.UseCases.Libros.Commands.UpdateLibro;
using App_Biblioteca.Application.UseCases.Libros.Queries.GetAllLibros;
using App_Biblioteca.Application.UseCases.Libros.Queries.GetLibroById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LibroController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllLibrosQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetLibroByIdQuery { Id = id });
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Create([FromBody] CreateLibroCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLibroCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { message = "El Id de la ruta no coincide con el cuerpo." });

        var result = await _mediator.Send(command);
        if (!result)
            return NotFound(new { message = $"Libro con Id {id} no encontrado." });

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLibroCommand { Id = id });
        if (!result)
            return NotFound(new { message = $"Libro con Id {id} no encontrado." });

        return NoContent();
    }
}
