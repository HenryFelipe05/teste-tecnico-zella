using Back_End.Domain.Account;
using Back_End.Infra.Data.Context;
using Microsoft.Extensions.Configuration;

namespace Back_End.Infra.Data.Identity
{
	public class AuthenticateServicecs : IAuthenticate
	{
		private readonly TodoDBContext _dbcontext;
		private readonly IConfiguration _configuration;

        public AuthenticateServicecs(TodoDBContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
			_configuration = configuration;
        }

        public Task<bool> AutenticarAsync(string email, string senha)
		{
			throw new NotImplementedException();
		}

		public string GerarToken(int codigoUsuario, string email)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UsuarioExiste(string email)
		{
			throw new NotImplementedException();
		}
	}
}
