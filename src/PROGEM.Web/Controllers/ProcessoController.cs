using PROGEM.Shared;
using MediatR;
using PROGEM.Application.Commands;
using PROGEM.Application.DTOs;
using PROGEM.Application.Handlers;
using PROGEM.Application.Queries;
using PROGEM.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PROGEM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProcessoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ProcessoDto>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] string? sortBy = null,
        [FromQuery] bool sortDesc = false,
        [FromQuery] NaturalezaProcesso? natureza = null,
        [FromQuery] CategoriaProcesso? categoria = null,
        [FromQuery] StatusProcesso? status = null,
        [FromQuery] string? search = null,
        [FromQuery] int? ano = null)
    {
        var query = new GetAllProcessosQuery(page, pageSize, sortBy, sortDesc, natureza, categoria, status, search, ano);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProcessoDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProcessoByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProcessoDto>> Create(CreateProcessoCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProcessoCommand command)
    {
        if (id != command.Id) return BadRequest();
        // Update handler not implemented yet
        return NoContent();
    }

    [HttpPost("{id}/reabrir")]
    public async Task<ActionResult<ProcessoDto>> Reabrir(Guid id, ReabrirProcessoCommand command)
    {
        var updatedCommand = command with { ProcessoId = id };
        var result = await _mediator.Send(updatedCommand);
        return Ok(result);
    }

    [HttpPost("{id}/encerramento")]
    public async Task<ActionResult<ProcessoDto>> RegistrarEncerramento(Guid id, RegistrarEncerramentoCommand command)
    {
        var updatedCommand = command with { ProcessoId = id };
        var result = await _mediator.Send(updatedCommand);
        return Ok(result);
    }

    [HttpGet("{id}/envolvidos")]
    public async Task<ActionResult<List<EnvolvidoDto>>> GetEnvolvidos(Guid id)
    {
        var result = await _mediator.Send(new GetEnvolvidosByProcessoQuery(id));
        return Ok(result);
    }

    [HttpGet("{id}/tramitacoes")]
    public async Task<ActionResult<List<TramitacaoDto>>> GetTramitacoes(Guid id)
    {
        var result = await _mediator.Send(new GetTramitacoesByProcessoQuery(id));
        return Ok(result);
    }

    [HttpGet("{id}/prorrogacoes")]
    public async Task<ActionResult<List<ProrrogacaoDto>>> GetProrrogacoes(Guid id)
    {
        var result = await _mediator.Send(new GetProrrogacoesByProcessoQuery(id));
        return Ok(result);
    }

    [HttpGet("{id}/historico")]
    public async Task<ActionResult<List<HistoricoDto>>> GetHistorico(Guid id)
    {
        var result = await _mediator.Send(new GetHistoricoByProcessoQuery(id));
        return Ok(result);
    }
}