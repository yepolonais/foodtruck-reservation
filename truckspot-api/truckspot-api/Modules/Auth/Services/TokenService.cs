using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using truckspot_api.Modules.Auth.Models;

namespace truckspot_api.Modules.Auth.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public (string accessToken, string refreshToken) CreateTokens(User user)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = CreateRefreshToken();

        return (accessToken, refreshToken);
    }
    
    private string CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ?? ""),
            new Claim(ClaimTypes.Name, user.UserName ?? "")
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Access token expiring after 1 hour
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    private string CreateRefreshToken()
    {
        var refreshToken = Guid.NewGuid().ToString();
        return refreshToken;
    }
    
    public string RefreshAccessToken(string refreshToken, User user)
    {

        if (IsValidRefreshToken(refreshToken, user))
        {
            return CreateAccessToken(user);
        }

        throw new Exception("Invalid refresh token");
    }

    // Exemple de validation de refresh token (tu pourrais aussi les stocker en base de données pour plus de sécurité)
    private bool IsValidRefreshToken(string refreshToken, User user)
    {
        // Exemple basique : tu peux ajouter un mécanisme pour vérifier si le refresh token est valide.
        return !string.IsNullOrEmpty(refreshToken);
    }
}
