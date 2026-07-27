using PROGEM.Domain.Enums;

namespace PROGEM.Domain.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateAsync(string email, string password);
    Task<string> GenerateAccessTokenAsync(Guid userId, string email, PerfilUsuario perfil);
    Task<string> GenerateRefreshTokenAsync();
    Task<(bool Success, string? Error)> ValidateRefreshTokenAsync(string token);
    Task<(bool Success, string? Error)> ValidateAccessTokenAsync(string token);
}