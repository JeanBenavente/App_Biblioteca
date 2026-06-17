using App_Biblioteca.Application.DTOs.Libro;
using App_Biblioteca.Application.UseCases.Libro;
using Microsoft.AspNetCore.Mvc;

namespace App_Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibroController : ControllerBase
{
    private readonly GetAllLibrosUseCase _getAllLibrosUseCase;
    private readonly GetLibroByIdUseCase _getLibroByIdUseCase;
    private readonly CreateLibroUseCase _createLibroUseCase;
    private readonly UpdateLibroUseCase _updateLibroUseCase;
    private readonly DeleteLibroUseCase _deleteLibroUseCase;

    public LibroController(
        GetAllLibrosUseCase getAllLibrosUseCase,
        GetLibroByIdUseCase getLibroByIdUseCase,
        CreateLibroUseCase createLibroUseCase,
        UpdateLibroUseCase updateLibroUseCase,
        DeleteLibroUseCase deleteLibroUseCase)
    {
        _getAllLibrosUseCase = getAllLibrosUseCase;
        _getLibroByIdUseCase = getLibroByIdUseCase;
        _createLibroUseCase = createLibroUseCase;
        _updateLibroUseCase = updateLibroUseCase;
        _deleteLibroUseCase = deleteLibroUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var libros = await _getAllLibrosUseCase.ExecuteAsync();

        return Ok(libros);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var libro = await _getLibroByIdUseCase.ExecuteAsync(id);

        if (libro is null)
        {
            return NotFound();
        }

        return Ok(libro);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLibroDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var libro = await _createLibroUseCase.ExecuteAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLibroDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updated = await _updateLibroUseCase.ExecuteAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deleteLibroUseCase.ExecuteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
