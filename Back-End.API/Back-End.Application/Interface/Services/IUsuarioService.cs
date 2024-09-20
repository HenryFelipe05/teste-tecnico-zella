using Back_End.Application.Commands;
using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Services
{
	public interface IUsuarioService
	{
		Task<UsuarioQuery> RecuperarUsuarioAsync(int codigoUsuario);
		Task<IEnumerable<UsuarioQuery>> RecuperarTodosUsuariosAsync();
		Task AdicionarUsuarioAsync(UsuarioCommand usuarioCommand);
		Task AtualizarUsuarioAsync(UsuarioCommand usuarioCommand, int codigoUsuario);
	}
}
