using MediatR;
using PROGEM.Application.Commands;
using PROGEM.Application.DTOs;
using PROGEM.Application.Handlers;
using PROGEM.Application.Queries;
using PROGEM.Shared;
using Microsoft.AspNetCore.Mvc;

namespace PROGEM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServidorController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServidorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ServidorDto>>> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] string? search = null,
        [FromQuery] string? secretaria = null,
        [FromQuery] bool? ativo = null)
    {
        var query = new GetAllServidoresQuery(page, pageSize, search, secretaria, ativo);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServidorDto>> GetById(Guid id)
    {
        return NotFound();
    }
}