using Back_End.Application.Commands;
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Interface.Services;
using Back_End.Domain.Models;

namespace Back_End.Application.Services
{
	public class TarefaService : ITarefaService
	{
		private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task AdicionarTarefaAsync(NovaTarefaCommand novaTarefaCommand)
		{
			var novaTarefa = new Tarefa
			{
				CodigoUsuario = novaTarefaCommand.CodigoUsuario,
				NomeTarefa = novaTarefaCommand.NomeTarefa,
				DescricaoTarefa = novaTarefaCommand.DescricaoTarefa,
				CodigoStatusTarefa = novaTarefaCommand.CodigoStatusTarefa
			};

			await _tarefaRepository.AdicionarTarefaAsync(novaTarefa);
		}

		public async Task AlterarTarefaAsync(int codigoTarefa, Tarefa tarefaAtualizada)
		{
			if (string.IsNullOrWhiteSpace(tarefaAtualizada.NomeTarefa))
			{
				throw new ArgumentException("O nome da tarefa não pode ser vazio.");
			}

			var tarefaExistente = await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);

			if (tarefaExistente == null)
			{
				throw new KeyNotFoundException("Tarefa não encontrada.");
			}

			tarefaExistente.NomeTarefa = tarefaAtualizada.NomeTarefa;
			tarefaExistente.DescricaoTarefa = tarefaAtualizada.DescricaoTarefa;
			tarefaExistente.CodigoStatusTarefa = tarefaAtualizada.CodigoStatusTarefa;

			await _tarefaRepository.AlterarTarefaAsync(codigoTarefa, tarefaExistente);
		}

		public async Task ExcluirTarefaAsync(int codigoTarefa)
		{
			var tarefaExistente = await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);

			if (tarefaExistente == null)
			{
				throw new KeyNotFoundException("Tarefa não encontrada.");
			}

			await _tarefaRepository.ExcluirTarefaAsync(tarefaExistente);
		}

		public async Task<Tarefa> RecuperarDetalhesTarefaAsync(int codigoTarefa)
		{
			return await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);
		}

		public async Task<IEnumerable<Tarefa>> RecuperarTarefasUsuarioAsync(int codigoUsuario)
		{
			return await _tarefaRepository.RecuperarTarefasUsuarioAsync(codigoUsuario);
		}
	}
}
