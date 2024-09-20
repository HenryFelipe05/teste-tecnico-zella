using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Back_End.Infra
{
	public static class DependencyInjectionSwagger
	{
		public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Autenticação de usuários todo list",
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme()
						{
							Reference  = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] {}
					}
				}); 
			});

			return services;
		}
	}
}
