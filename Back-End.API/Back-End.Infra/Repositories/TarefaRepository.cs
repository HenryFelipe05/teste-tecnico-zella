#nullable disable
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Queries;
using Back_End.Domain.Models;
using Back_End.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Infra.Repositories
{
	public class TarefaRepository : ITarefaRepository
	{
		private readonly TodoDBContext _dbcontext;

        public TarefaRepository(TodoDBContext dbcontext)
        {
			_dbcontext = dbcontext;
        }

        public async Task AdicionarTarefaAsync(Tarefa novaTarefa)
		{
			await _dbcontext.Tarefas.AddAsync(novaTarefa);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task AlterarTarefaAsync(Tarefa tarefa)
		{
			_dbcontext.Entry(tarefa).State = EntityState.Modified;
			await _dbcontext.SaveChangesAsync();
		}

		public async Task ExcluirTarefaAsync(Tarefa tarefa)
		{
			_dbcontext.Tarefas.Remove(tarefa);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task<TarefaQuery> RecuperarDetalhesTarefaAsync(int codigoTarefa)
		{
			return await _dbcontext.Tarefas.Where(t => t.CodigoTarefa == codigoTarefa)
			.Select(t => new TarefaQuery
            {
                CodigoTarefa = t.CodigoTarefa,
				CodigoUsuario = t.CodigoUsuario,
				NomeTarefa = t.NomeTarefa,
				DescricaoTarefa = t.DescricaoTarefa,
				CodigoStatusTarefa = t.CodigoStatusTarefa,
            }).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<TarefaQuery>> RecuperarTarefasUsuarioAsync(int codigoUsuario)
		{
			return await _dbcontext.Tarefas.Where(t => t.CodigoUsuario == codigoUsuario).Select(t => new TarefaQuery
            {
                CodigoTarefa = t.CodigoTarefa,
                CodigoUsuario = t.CodigoUsuario,
                NomeTarefa = t.NomeTarefa,
                DescricaoTarefa = t.DescricaoTarefa,
                CodigoStatusTarefa = t.CodigoStatusTarefa,
            }).ToListAsync();
		}
	}
}
