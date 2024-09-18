using Back_End.Application.Commands;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Repositories
{
	public interface ITarefaRepository
	{
		Task<IEnumerable<Tarefa>> RecuperarTarefasUsuarioAsync(int codigoUsuario);
		Task<Tarefa> RecuperarDetalhesTarefaAsync(int codigoTarefa);
		Task AdicionarTarefaAsync(Tarefa novaTarefa);
		Task AlterarTarefaAsync(Tarefa tarefa);
		Task ExcluirTarefaAsync(Tarefa tarefa);
	}
}
