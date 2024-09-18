using Back_End.Application.Commands;
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Interface.Services;
using Back_End.Application.Queries;
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

        public async Task AdicionarTarefaAsync(TarefaCommand tarefaCommand)
		{
			var novaTarefa = new Tarefa
			{
				CodigoUsuario = tarefaCommand.CodigoUsuario,
				NomeTarefa = tarefaCommand.NomeTarefa,
				DescricaoTarefa = tarefaCommand.DescricaoTarefa,
				CodigoStatusTarefa = tarefaCommand.CodigoStatusTarefa
			};

			await _tarefaRepository.AdicionarTarefaAsync(novaTarefa);
		}

		public async Task AlterarTarefaAsync(TarefaQuery tarefaQuery, int codigoTarefa, int codigoUsuario)
		{
			if (string.IsNullOrWhiteSpace(tarefaQuery.NomeTarefa))
				throw new ArgumentException("O nome da tarefa não pode ser vazio.");

			if (tarefaQuery.CodigoStatusTarefa == null)
				throw new ArgumentException("O Código do status da tarefa não pode ser vazio.");

			var novaTarefa = new Tarefa
			{ 
				CodigoTarefa = codigoTarefa,
				CodigoUsuario = codigoUsuario,
				NomeTarefa = tarefaQuery.NomeTarefa,
				DescricaoTarefa = tarefaQuery.DescricaoTarefa,
				CodigoStatusTarefa = tarefaQuery.CodigoStatusTarefa
			};

			await _tarefaRepository.AlterarTarefaAsync(novaTarefa);
		}

		public async Task ExcluirTarefaAsync(int codigoTarefa)
		{
			var tarefaExistente = await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);

			if (tarefaExistente == null)
				throw new KeyNotFoundException("Tarefa não encontrada.");
			
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
