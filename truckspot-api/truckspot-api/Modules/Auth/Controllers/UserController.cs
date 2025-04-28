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
    
    public UserController(UserRepository userRepository, AuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _userRepository.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateUser userDto)
    {
        var newUser = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
        };
        
        await _userRepository.CreateAsync(newUser);
        
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUser userDto)
    {
        var result =
            await _authService.RegisterAsync(userDto.Email, userDto.Password, userDto.FirstName, userDto.LastName);
        if (result)
        {
            return Ok(new { Message = "User registered successfully" });
        }
        return BadRequest(new { Message = "User already exists" });
    }
    
    // Endpoint pour la connexion
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _authService.LoginAsync(request.Email, request.Password);
        if (user == null)
        {
            return Unauthorized(new { Message = "Invalid email or password" });
        }

        // Gérer la génération du token ici (si tu utilises JWT)
        return Ok(new { Message = "Login successful", User = user });
    }
}