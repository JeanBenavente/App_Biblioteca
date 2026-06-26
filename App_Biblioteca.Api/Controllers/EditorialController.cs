using App_Biblioteca.Application.UseCases.Editoriales.Commands.CreateEditorial;
using App_Biblioteca.Application.UseCases.Editoriales.Commands.DeleteEditorial;
using App_Biblioteca.Application.UseCases.Editoriales.Commands.UpdateEditorial;
using App_Biblioteca.Application.UseCases.Editoriales.Queries.GetAllEditoriales;
using App_Biblioteca.Application.UseCases.Editoriales.Queries.GetEditorialById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EditorialController : ControllerBase
{
    private readonly IMediator _mediator;

    public EditorialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllEditorialesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetEditorialByIdQuery { Id = id });
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Create([FromBody] CreateEditorialCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEditorialCommand command)
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
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteEditorialCommand { Id = id });
        if (!result)
            return NotFound(new { message = $"Editorial con Id {id} no encontrada." });

        return NoContent();
    }
}
