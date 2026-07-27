using MediatR;
using PROGEM.Application.Commands;
using PROGEM.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PROGEM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginQuery query)
    {
        try
        {
            var token = (string)await _mediator.Send(query);
            return Ok(new AuthResponse { Token = token });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }
}

public class LoginQuery
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
}