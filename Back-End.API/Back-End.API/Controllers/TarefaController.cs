using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Domain.Models;
using Back_End.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TarefaController : ControllerBase
	{
		public readonly ITarefaService _tarefaService;

		public TarefaController(ITarefaService tarefaService)
		{
			_tarefaService = tarefaService;
		}

		[HttpGet("tarefas-usuario")]
		public async Task<ActionResult<IEnumerable<Tarefa>>> RecuperarTarefasUsuario()
		{
			var tarefas = await _tarefaService.RecuperarTarefasUsuarioAsync(User.RecuperarCodigoUsuario());

			if (tarefas == null)
				return NoContent();
			else
				return Ok(tarefas);
		}

		[HttpGet("detalhes-tarefa")]
		public async Task<ActionResult<Tarefa>> RecuperarDetalhesTarefa([FromQuery] int codigoTarefa)
		{
			if (codigoTarefa <= 0)
				return BadRequest("Código da tarefa inválido.");

			var tarefa = await _tarefaService.RecuperarDetalhesTarefaAsync(codigoTarefa);

			if (tarefa == null)
				return NoContent();
			else
				return Ok(tarefa);
		}

		[HttpPost("nova-tarefa")]
		public async Task<ActionResult> AdicionarNovaTarefa([FromBody] TarefaCommand tarefaCommand)
		{
			if (tarefaCommand == null)
				return BadRequest();

			await _tarefaService.AdicionarTarefaAsync(tarefaCommand, User.RecuperarCodigoUsuario());

			return Created();
		}

		[HttpPut("alterar-tarefa")]
		public async Task<ActionResult> AlterarTarefa([FromQuery] int codigoTarefa, [FromBody] TarefaCommand tarefaCommand)
		{
			if (codigoTarefa < 0)
				return BadRequest("Código da tarefa inválido.");

			await _tarefaService.AlterarTarefaAsync(tarefaCommand, codigoTarefa, User.RecuperarCodigoUsuario());
			return Ok();	
		}

		[HttpDelete("excluir-tarefa")]
		public async Task<ActionResult> ExcluirTarefa([FromQuery] int codigoTarefa)
		{
			if (codigoTarefa <= 0)
				return BadRequest("Código da tarefa inválido.");

			await _tarefaService.ExcluirTarefaAsync(codigoTarefa);
			return Ok();
		}
	}
}
