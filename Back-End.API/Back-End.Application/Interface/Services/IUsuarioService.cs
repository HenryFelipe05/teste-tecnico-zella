using Back_End.Application.Commands;
using Back_End.Application.Queries;

namespace Back_End.Application.Interface.Services
{
	public interface IUsuarioService
	{
		Task<UsuarioQuery> RecuperarUsuarioAsync(int codigoUsuario);
		Task<IEnumerable<UsuarioQuery>> RecuperarTodosUsuariosAsync();
		Task<UsuarioQuery> AdicionarUsuarioAsync(UsuarioCommand usuarioCommand);
		Task AtualizarUsuarioAsync(UsuarioCommand usuarioCommand, int codigoUsuario);
	}
}
