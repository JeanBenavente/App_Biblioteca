using MediatR;
using App_Biblioteca.Domain.DTOs.Autor;

namespace App_Biblioteca.Application.UseCases.Autores.Queries.GetAllAutores;

public class GetAllAutoresQuery : IRequest<IEnumerable<AutorResponseDto>>
{
}
