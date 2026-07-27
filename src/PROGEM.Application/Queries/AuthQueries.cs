using MediatR;

namespace PROGEM.Application.Queries;

public record LoginQuery(string Email, string Password) : IRequest<string>;

public record GetUserByEmailQuery(string Email) : IRequest<ServidorDto?>;