using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Domain.Enums;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginQuery, string>
{
    private readonly IAuthService _authService;
    private readonly IServidorRepository _servidorRepository;

    public LoginHandler(IAuthService authService, IServidorRepository servidorRepository)
    {
        _authService = authService;
        _servidorRepository = servidorRepository;
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var servidores = await _servidorRepository.FindAsync(s => s.Email!.Value == request.Email, cancellationToken);
        var servidor = servidores.FirstOrDefault()
            ?? throw new NotFoundException("Invalid credentials.");

        if (!servidor.Ativo)
            throw new UnauthorizedAccessException("Usuario is inactive.");

        return await _authService.GenerateAccessTokenAsync(servidor.Id, servidor.Email!.Value, PerfilUsuario.Servidor);
    }
}