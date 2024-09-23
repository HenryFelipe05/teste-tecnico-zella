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
			if (string.IsNullOrWhiteSpace(tarefaCommand.NomeTarefa))
				throw new ArgumentException("O nome da tarefa não pode ser vazio.");

			if (tarefaCommand.CodigoStatusTarefa <= 0)
				throw new ArgumentException("O Código do status da tarefa inválido.");

			var dadosTarefa = Tarefa.MapearDadosTarefa(tarefaCommand.NomeTarefa, tarefaCommand.DescricaoTarefa, tarefaCommand.CodigoUsuario, tarefaCommand.CodigoStatusTarefa);

			await _tarefaRepository.AdicionarTarefaAsync(dadosTarefa);
		}

		public async Task AlterarTarefaAsync(TarefaCommand tarefaCommand, int codigoTarefa, int codigoUsuario)
		{
			if (string.IsNullOrWhiteSpace(tarefaCommand.NomeTarefa))
				throw new ArgumentException("O nome da tarefa não pode ser vazio.");

			if (tarefaCommand.CodigoStatusTarefa <= 0)
				throw new ArgumentException("O Código do status da tarefa inválido.");

            var dadosTarefa = Tarefa.MapearDadosTarefa(tarefaCommand.NomeTarefa, tarefaCommand.DescricaoTarefa, codigoUsuario, tarefaCommand.CodigoStatusTarefa, codigoTarefa);

            await _tarefaRepository.AlterarTarefaAsync(dadosTarefa);
		}

		public async Task ExcluirTarefaAsync(int codigoTarefa)
		{
			var tarefa = await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);

			if (tarefa == null)
				throw new KeyNotFoundException("Tarefa não encontrada.");

			var tarefaMapeada = Tarefa.MapearDadosTarefa(tarefa.NomeTarefa, tarefa.DescricaoTarefa, tarefa.CodigoUsuario, tarefa.CodigoStatusTarefa, tarefa.CodigoTarefa);
			
			await _tarefaRepository.ExcluirTarefaAsync(tarefaMapeada);
		}

		public async Task<TarefaQuery> RecuperarDetalhesTarefaAsync(int codigoTarefa)
		{
			return await _tarefaRepository.RecuperarDetalhesTarefaAsync(codigoTarefa);
		}

		public async Task<IEnumerable<TarefaQuery>> RecuperarTarefasUsuarioAsync(int codigoUsuario)
		{
			return await _tarefaRepository.RecuperarTarefasUsuarioAsync(codigoUsuario);
		}
	}
}
