using MediatR;
using PROGEM.Application.Commands;
using PROGEM.Application.DTOs;
using PROGEM.Application.Handlers;
using PROGEM.Application.Queries;
using PROGEM.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PROGEM.Web.Controllers;

public class RelatorioController : Controller
{
    private readonly IMediator _mediator;

    public RelatorioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet("api/export")]
    public async Task<IActionResult> Export([FromQuery] RelatorioFiltroQuery filtro)
    {
        // Export logic
        return Ok();
    }
}

public class RelatorioFiltroQuery
{
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? Natureza { get; set; }
    public string? Categoria { get; set; }
}