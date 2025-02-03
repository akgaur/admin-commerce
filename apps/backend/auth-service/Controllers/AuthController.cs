using Microsoft.AspNetCore.Mvc;
using AuthService.Services;
using Shared.Models;

namespace AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // TODO: Validate user credentials against database
        // For demo purposes, we'll create a mock user
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = request.Email,
            Name = "Test User",
            Role = "Admin",
            CreatedAt = DateTime.UtcNow
        };

        var token = await _authService.GenerateTokenAsync(user);
        return Ok(new { token, user });
    }

    [HttpPost("validate")]
    public async Task<IActionResult> ValidateToken([FromBody] ValidateTokenRequest request)
    {
        var isValid = await _authService.ValidateTokenAsync(request.Token);
        return Ok(new { isValid });
    }
}

public class LoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class ValidateTokenRequest
{
    public string Token { get; set; } = null!;
}
