#nullable disable
using Back_End.Application.Interface.Repositories;
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

		public async Task<Tarefa> RecuperarDetalhesTarefaAsync(int codigoTarefa)
		{
			return await _dbcontext.Tarefas.Where(t => t.CodigoTarefa == codigoTarefa).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Tarefa>> RecuperarTarefasUsuarioAsync(int codigoUsuario)
		{
			return await _dbcontext.Tarefas.Where(t => t.CodigoUsuario == codigoUsuario).ToListAsync();
		}
	}
}
