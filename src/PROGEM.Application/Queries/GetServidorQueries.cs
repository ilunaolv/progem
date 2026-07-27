using MediatR;

namespace PROGEM.Application.Queries;

public record GetAllServidoresQuery(
    int Page,
    int PageSize,
    string? Search,
    string? Secretaria,
    bool? Ativo
) : IRequest<PagedResult<ServidorDto>>;