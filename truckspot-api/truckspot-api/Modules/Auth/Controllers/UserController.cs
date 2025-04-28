using Microsoft.AspNetCore.Mvc;
using truckspot_api.Modules.Auth.DTOs;
using truckspot_api.Modules.Auth.Models;
using truckspot_api.Modules.Auth.Repositories;

namespace truckspot_api.Modules.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly UserRepository _userRepository;
    
    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
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
}