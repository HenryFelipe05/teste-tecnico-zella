using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Application.Services;
using Back_End.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuararioService;

        public UsuarioController(IUsuarioService usuararioService)
        {
            _usuararioService = usuararioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> RecuperarTodosUsuarios()
        {
            var usuarios = await _usuararioService.RecuperarTodosUsuariosAsync();

            if (usuarios == null)
                return NoContent();
            else
                return Ok(usuarios);
        }

		[HttpGet("{codigoUsuario}")]
		public async Task<ActionResult<Usuario>> RecuperarUsuario([FromRoute] int codigoUsuario)
		{
			var usuario = await _usuararioService.RecuperarUsuarioAsync(codigoUsuario);

			if (usuario == null)
				return NoContent();
			else
				return Ok(usuario);
		}

		[HttpPost]
		public async Task<ActionResult> AdicionarUsuario([FromBody] UsuarioCommand usuarioCommand)
		{
			if (usuarioCommand == null)
				return BadRequest();

			await _usuararioService.AdicionarUsuarioAsync(usuarioCommand);

			return Created();
		}
	}
}
