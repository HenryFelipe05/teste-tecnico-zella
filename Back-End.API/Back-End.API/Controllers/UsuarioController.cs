#nullable disable
using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Application.Queries;
using Back_End.Domain.Account;
using Back_End.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuararioService;
        private readonly IAuthenticate _authenticate;

        public UsuarioController(IUsuarioService usuararioService, 
                                 IAuthenticate authenticate)
        {
            _usuararioService = usuararioService;
            _authenticate = authenticate;
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
            if (codigoUsuario < 0)
                return BadRequest("Código do usuário inválido.");

            var usuario = await _usuararioService.RecuperarUsuarioAsync(codigoUsuario);

            if (usuario == null)
                return NoContent();
            else
                return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<TokenUsuarioQuery>> AdicionarUsuario([FromBody] UsuarioCommand usuarioCommand)
        {
            if (usuarioCommand == null)
                return BadRequest("Dados inválidos.");

            var emailExiste = await _authenticate.UsuarioExiste(usuarioCommand.Email);

            if (emailExiste)
                return BadRequest("Esse e-mail já possui uma conta vinculada.");

            await _usuararioService.AdicionarUsuarioAsync(usuarioCommand);

            var token =  await _authenticate.GerarToken()

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarUsuario([FromBody] UsuarioCommand usuarioCommand, [FromQuery] int codigoUsuario)
        {
            if (usuarioCommand == null)
                return BadRequest("Dados inválidos.");

            if (codigoUsuario < 0)
                return BadRequest("Código do usuário inválido.");

            await _usuararioService.AtualizarUsuarioAsync(usuarioCommand, codigoUsuario);

            return Ok("Usuário atualizado com sucesso.");
        }
    }
}
