﻿using Back_End.Application.Commands;
using Back_End.Application.Queries;
using Back_End.Domain.Models;

namespace Back_End.Application.Interface.Repositories
{
	public interface ITarefaRepository
	{
		Task<IEnumerable<TarefaQuery>> RecuperarTarefasUsuarioAsync(int codigoUsuario);
		Task<TarefaQuery> RecuperarDetalhesTarefaAsync(int codigoTarefa);
		Task AdicionarTarefaAsync(Tarefa novaTarefa);
		Task AlterarTarefaAsync(Tarefa tarefa);
		Task AlterarStatusTarefaAsync(int codigoTarefa, int codigoStatusTarefa);
        Task ExcluirTarefaAsync(Tarefa tarefa);
	}
}
