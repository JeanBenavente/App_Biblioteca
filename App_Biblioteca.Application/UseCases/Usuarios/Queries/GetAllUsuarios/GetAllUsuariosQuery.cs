using MediatR;
using App_Biblioteca.Domain.DTOs.Usuario;

namespace App_Biblioteca.Application.UseCases.Usuarios.Queries.GetAllUsuarios;

public class GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioResponseDto>>
{
}
