namespace truckspot_api.Modules.Auth.DTOs;

public class LoginResponseDto
{
    public bool Success { get; set; }
    
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    
}

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }
}
