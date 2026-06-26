using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;

namespace App_Biblioteca.Application.UseCases.Autores.Queries.GetAutorById;

public class GetAutorByIdQuery : IRequest<AutorResponseDto>
{
    public int Id { get; set; }
}
