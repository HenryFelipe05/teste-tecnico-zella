#nullable disable
using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Application.Queries;
using Back_End.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuararioService;

        public UsuarioController(IUsuarioService usuararioService)
        {
            _usuararioService = usuararioService;
        }

        [HttpGet("usuarios")]
		public async Task<ActionResult<IEnumerable<UsuarioQuery>>> RecuperarTodosUsuarios()
        {
            var usuarios = await _usuararioService.RecuperarTodosUsuariosAsync();

            if (usuarios == null)
                return NoContent();
            else
                return Ok(usuarios);
        }

        [HttpGet("usuario")]
		public async Task<ActionResult<UsuarioQuery>> RecuperarUsuario()
        {
            var usuario = await _usuararioService.RecuperarUsuarioAsync(User.RecuperarCodigoUsuario());

            if (usuario == null)
                return NoContent();
            else
                return Ok(usuario);
        }

        [HttpPut("atualizar-usuario")]
		public async Task<ActionResult> AtualizarUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            if (usuarioCommand == null)
                return BadRequest("Dados inválidos.");

            await _usuararioService.AtualizarUsuarioAsync(usuarioCommand, User.RecuperarCodigoUsuario());

            return Ok("Usuário atualizado com sucesso.");
        }
    }
}
