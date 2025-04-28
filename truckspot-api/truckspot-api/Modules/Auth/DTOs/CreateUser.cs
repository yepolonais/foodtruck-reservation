namespace truckspot_api.Modules.Auth.DTOs;

public class CreateUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public string Password { get; set; } = null!;
}