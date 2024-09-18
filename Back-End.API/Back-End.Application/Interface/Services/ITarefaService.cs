using Back_End.Application.Commands;
using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Services
{
	public interface ITarefaService
	{
		Task<IEnumerable<Tarefa>> RecuperarTarefasUsuarioAsync(int codigoUsuario);
		Task<Tarefa> RecuperarDetalhesTarefaAsync(int codigoTarefa);
		Task AdicionarTarefaAsync(TarefaCommand novaTarefa);
		Task AlterarTarefaAsync(TarefaQuery tarefa, int codigoTarefa, int codigoUsuario);
		Task ExcluirTarefaAsync(int codigoTarefa);
	}
}
