#nullable disable
using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Application.Queries;
using Back_End.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutenticacaoController : ControllerBase
	{
		private readonly IUsuarioService _usuararioService;
		private readonly IAuthenticate _authenticate;

		public AutenticacaoController(IUsuarioService usuararioService,
									  IAuthenticate authenticate)
		{
			_usuararioService = usuararioService;
			_authenticate = authenticate;
		}

		[HttpPost("registrar")]
		public async Task<ActionResult<TokenUsuarioQuery>> AdicionarUsuario([FromBody] UsuarioCommand usuarioCommand)
		{
			if (usuarioCommand == null)
				return BadRequest("Dados inválidos.");

			var emailExiste = await _authenticate.UsuarioExiste(usuarioCommand.Email);

			if (emailExiste)
				return BadRequest("Esse e-mail já possui uma conta vinculada.");

			var usuario = await _usuararioService.AdicionarUsuarioAsync(usuarioCommand);

			if (usuario == null)
				return BadRequest("Ocorreu um erro ao cadastrar o usuário.");

			var token = _authenticate.GerarToken(usuario.CodigoUsuario, usuario.Email);

			return new TokenUsuarioQuery
			{
				Token = token
			};
		}

		[HttpPost("login")]
		public async Task<ActionResult<TokenUsuarioQuery>> LoginUsuario([FromBody] LoginCommand loginCommand)
		{
			if (loginCommand == null)
				return BadRequest("Dados inválidos.");

			var usuarioExiste = await _authenticate.UsuarioExiste(loginCommand.Email);

			if (!usuarioExiste)
				return Unauthorized("Usuário com o email informado não existe.");

			var result = await _authenticate.AutenticarAsync(loginCommand.Email, loginCommand.Senha);

			if (!result)
				return Unauthorized("Email ou senha inválido(a).");

			var usuario = await _authenticate.RecuperarUsuarioPorEmail(loginCommand.Email);
			var token = _authenticate.GerarToken(usuario.CodigoUsuario, usuario.Email);

			return new TokenUsuarioQuery
			{
				Token = token
			};
		}
	}
}
