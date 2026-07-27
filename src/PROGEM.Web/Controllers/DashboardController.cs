using MediatR;
using PROGEM.Application.Queries;
using PROGEM.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PROGEM.Web.Controllers;

public class DashboardController : Controller
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet("api/data")]
    public async Task<ActionResult<DashboardData>> GetDashboardData()
    {
        var result = await _mediator.Send(new GetDashboardQuery());
        return Ok(result);
    }
}