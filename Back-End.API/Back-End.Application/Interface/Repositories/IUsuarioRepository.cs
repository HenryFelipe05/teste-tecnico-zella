using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Repositories
{
	public interface IUsuarioRepository
	{
		Task<UsuarioQuery> RecuperarUsuarioAsync(int codigoUsuario);
		Task<IEnumerable<UsuarioQuery>> RecuperarTodosUsuariosAsync();
		Task<UsuarioQuery> AdicionarUsuarioAsync(Usuario novoUsuario);
		Task AtualizarUsuarioAsync(Usuario usuario);
	}
}
