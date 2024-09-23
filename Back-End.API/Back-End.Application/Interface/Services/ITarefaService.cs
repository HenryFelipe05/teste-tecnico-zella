using Back_End.Application.Commands;
using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Services
{
	public interface ITarefaService
	{
		Task<IEnumerable<TarefaQuery>> RecuperarTarefasUsuarioAsync(int codigoUsuario);
		Task<TarefaQuery> RecuperarDetalhesTarefaAsync(int codigoTarefa);
		Task AdicionarTarefaAsync(TarefaCommand novaTarefa, int codigoUsuario);
		Task AlterarTarefaAsync(TarefaCommand tarefaCommand, int codigoTarefa, int codigoUsuario);
		Task ExcluirTarefaAsync(int codigoTarefa);
	}
}
