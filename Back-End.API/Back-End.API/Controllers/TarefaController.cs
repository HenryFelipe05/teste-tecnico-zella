using Back_End.Application.Commands;
using Back_End.Application.Interface.Services;
using Back_End.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		public readonly ITarefaService _tarefaService;

		public TarefaController(ITarefaService tarefaService)
		{
			_tarefaService = tarefaService;
		}

		[HttpGet("{codigoUsuario}")]
		public async Task<ActionResult<IEnumerable<Tarefa>>> RecuperarTarefasUsuario(int codigoUsuario)
		{
			if (codigoUsuario <= 0)
				return BadRequest("Código do usuário inválido.");

			var tarefas = await _tarefaService.RecuperarTarefasUsuarioAsync(codigoUsuario);

			if (tarefas == null)
				return NoContent();
			else
				return Ok(tarefas);
		}

		[HttpGet]
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

		[HttpPost]
		public async Task<ActionResult> AdicionarNovaTarefa([FromBody] NovaTarefaCommand novaTarefa)
		{
			if (novaTarefa == null)
				return BadRequest();

			await _tarefaService.AdicionarTarefaAsync(novaTarefa);

			return Ok();
		}
	}
}
