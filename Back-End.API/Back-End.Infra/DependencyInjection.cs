#nullable disable
using Back_End.Application.Interface.Repositories;
using Back_End.Application.Interface.Services;
using Back_End.Application.Services;
using Back_End.Infra.Data.Context;
using Back_End.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Back_End.Infra
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TodoDBContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddAuthentication(options => 
			{ 
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidAudience = configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});

			#region [ Repositories ]
			services.AddScoped<ITarefaRepository, TarefaRepository>();
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			#endregion

			#region [ Services ]
			services.AddScoped<ITarefaService, TarefaService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			#endregion

			return services;
		}
	}
}
