using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using truckspot_api.Modules.Auth.DTOs;
using truckspot_api.Modules.Auth.Models;
using truckspot_api.Modules.Auth.Repositories;
using truckspot_api.Modules.Auth.Services;

namespace truckspot_api.Modules.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly AuthService _authService;
    private readonly TokenService _tokenService;
    
    public UserController(UserRepository userRepository, AuthService authService, TokenService tokenService)
    {
        _userRepository = userRepository;
        _authService = authService;
        _tokenService = tokenService;
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _userRepository.GetAsync(id);
        
        return user is null ? NotFound() : user;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUser userDto)
    {
        var result = await _authService.RegisterAsync(userDto.Email, userDto.Password, userDto.FirstName, userDto.LastName);
        if (result)
        {
            return Ok(new { Message = "User registered successfully" });
        }
        return BadRequest(new { Message = "User already exists" });
    }
    
   
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _authService.LoginAsync(request.Email, request.Password);
        if (user == null)
        {
            return Unauthorized(new { Message = "Invalid email or password" });
        }
        
        var (accessToken, refreshToken) = _tokenService.CreateTokens(user);

        // Stocker le refresh token en bdd
        
        var response = new LoginResponseDto
        {
            Success = true,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return Ok(response);
    }
    
    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] RefreshTokenRequest request)
    { // à faire stocker le refresh token en base
        return Ok(new
        {
            accessToken = "newAccessToken",
            message = "Access token refreshed"
        });
    }
}