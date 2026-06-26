using App_Biblioteca.Application.UseCases.Usuarios.Commands.CreateUsuario;
using App_Biblioteca.Application.UseCases.Usuarios.Commands.DeleteUsuario;
using App_Biblioteca.Application.UseCases.Usuarios.Commands.UpdateUsuario;
using App_Biblioteca.Application.UseCases.Usuarios.Queries.GetAllUsuarios;
using App_Biblioteca.Application.UseCases.Usuarios.Queries.GetUsuarioById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrador")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsuariosQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetUsuarioByIdQuery { Id = id });
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { message = "El Id de la ruta no coincide con el cuerpo." });

        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteUsuarioCommand { Id = id });
        if (!result)
            return NotFound(new { message = $"Usuario con Id {id} no encontrado." });

        return NoContent();
    }
}
