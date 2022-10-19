using Microsoft.AspNetCore.Mvc;
using qna.Models;
using qna.Services;

namespace qna.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequestBody loginRequestBody)
    {
        var authToken = await _authService.GetAuthtoken(loginRequestBody.Username, loginRequestBody.Password);
        if (authToken == null)
        {
            return Unauthorized();
        }
        return Ok(authToken);
    }
}
