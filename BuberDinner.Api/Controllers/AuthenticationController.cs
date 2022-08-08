using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authenticationResult = _authenticationService.Register(registerRequest.FirstName,
            registerRequest.LastName, registerRequest.Email, registerRequest.Password);
        
        return Ok(new AuthenticationResponse(authenticationResult.Id, authenticationResult.FirstName, 
            authenticationResult.LastName, authenticationResult.Email, authenticationResult.Token));
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authenticationResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);
        
        return Ok(new AuthenticationResponse(authenticationResult.Id, authenticationResult.FirstName, 
            authenticationResult.LastName, authenticationResult.Email, authenticationResult.Token));
    }
}