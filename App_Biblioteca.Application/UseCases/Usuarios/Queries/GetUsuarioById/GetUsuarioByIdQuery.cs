using MediatR;
using App_Biblioteca.Domain.DTOs.Usuario;

namespace App_Biblioteca.Application.UseCases.Usuarios.Queries.GetUsuarioById;

public class GetUsuarioByIdQuery : IRequest<UsuarioResponseDto>
{
    public int Id { get; set; }
}
