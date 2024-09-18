using Back_End.Application.Commands;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Services
{
	public interface ITarefaService
	{
		Task<IEnumerable<Tarefa>> RecuperarTarefasUsuarioAsync(int codigoUsuario);
		Task<Tarefa> RecuperarDetalhesTarefaAsync(int codigoTarefa);
		Task AdicionarTarefaAsync(NovaTarefaCommand novaTarefa);
		Task AlterarTarefaAsync(int codigoTarefa, Tarefa tarefa);
		Task ExcluirTarefaAsync(int codigoTarefa);
	}
}
