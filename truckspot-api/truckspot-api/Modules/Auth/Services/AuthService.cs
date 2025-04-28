using truckspot_api.Modules.Auth.Models;
using truckspot_api.Modules.Auth.Repositories;

using Microsoft.AspNetCore.Identity;

namespace truckspot_api.Modules.Auth.Services;

public class AuthService
{
    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        var existingUser = await _userRepository.GetByEmailAsync(email);
        if (existingUser is not null)
        {
            return false;
        }

        var passwordHasher = new PasswordHasher<User>();
        var user = new User
        {
            Email = email,
            UserName = email,
            FirstName = firstName,
            LastName = lastName,
            Roles = new List<string> { "USER" }
        };
        user.PasswordHash = passwordHasher.HashPassword(user, password);

        await _userRepository.CreateAsync(user);
        return true;
    }
    
    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return null;
        }

        var valid = CheckPassword(user, password);
        return valid ? user : null;
    }
    
    private bool CheckPassword(User user, string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        if (string.IsNullOrEmpty(user.PasswordHash))
        {
            return false; 
        }
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
    
}