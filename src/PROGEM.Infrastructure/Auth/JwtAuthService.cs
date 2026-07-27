using PROGEM.Domain.Interfaces;
using PROGEM.Domain.Enums;
using PROGEM.Domain.ValueObjects;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PROGEM.Infrastructure.Auth;

public class JwtAuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public JwtAuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> AuthenticateAsync(string email, string password)
    {
        await Task.CompletedTask;
        return string.Empty;
    }

    public async Task<string> GenerateAccessTokenAsync(Guid userId, string email, PerfilUsuario perfil)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(_configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret is not configured."));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, perfil.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string> GenerateRefreshTokenAsync()
    {
        var randomNumber = new byte[64];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<(bool Success, string? Error)> ValidateRefreshTokenAsync(string token)
    {
        await Task.CompletedTask;
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ValidateAccessTokenAsync(string token)
    {
        await Task.CompletedTask;
        return (true, null);
    }
}