#nullable disable
using Back_End.Domain.Account;
using Back_End.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<bool> AutenticarAsync(string email, string senha)
		{
			var usuario = await _dbcontext.Usuarios.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync(); 

			if (usuario == null) 
				return false;

			if (senha != usuario.Senha)
				return false;

			return true;
		}

		public string GerarToken(int codigoUsuario, string email)
		{
			var claims = new[]
			{
				new Claim("codigoUsuario", codigoUsuario.ToString()),
				new Claim("email", email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
			var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
			var expiration = DateTime.UtcNow.AddHours(1);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: expiration,
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<bool> UsuarioExiste(string email)
		{
            var usuario = await _dbcontext.Usuarios.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

			return true;
        }
	}
}
