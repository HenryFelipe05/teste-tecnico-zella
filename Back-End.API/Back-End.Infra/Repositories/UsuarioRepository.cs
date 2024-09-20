#nullable disable
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Queries;
using Back_End.Domain.Models;
using Back_End.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Infra.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly TodoDBContext _dbcontext;

		public UsuarioRepository(TodoDBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public async Task AdicionarUsuarioAsync(Usuario novoUsuario)
		{
			await _dbcontext.Usuarios.AddAsync(novoUsuario);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task AtualizarUsuarioAsync(Usuario usuario)
		{
			_dbcontext.Entry(usuario).State = EntityState.Modified;
			await _dbcontext.SaveChangesAsync();
		}

		public async Task<IEnumerable<UsuarioQuery>> RecuperarTodosUsuariosAsync()
		{
			return await _dbcontext.Usuarios
			.Select(u => new UsuarioQuery
			{
				CodigoUsuario = u.CodigoUsuario,
				Email = u.Email,
				CodigoGenero = u.CodigoGenero
			}).ToListAsync();
		}

		public async Task<UsuarioQuery> RecuperarUsuarioAsync(int codigoUsuario)
		{
			return await _dbcontext.Usuarios.Where(u => u.CodigoUsuario == codigoUsuario)
			.Select(u => new UsuarioQuery
			{
				CodigoUsuario = u.CodigoUsuario,
				Email = u.Email,
				CodigoGenero = u.CodigoGenero
			}).FirstOrDefaultAsync();
		}
	}
}
