using Microsoft.AspNetCore.Mvc;
using ReservationsSystem.Application.Features.Auth;

namespace ReservationsSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest, CancellationToken ct)
    {
        var result = await authService.RegisterAsync(registerRequest, ct);

        return result.IsSuccess
            ? CreatedAtAction(nameof(Register), new { id = result.Value.UserId }, result.Value)
            : BadRequest(new { result.Error.Code, result.Error.Description });
    }
}