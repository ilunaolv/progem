using MediatR;
using PROGEM.Domain.Enums;
using PROGEM.Shared;

namespace PROGEM.Application.Queries;

public record GetProcessoByIdQuery(Guid Id) : IRequest<ProcessoDto?>;

public record GetAllProcessosQuery(
    int Page,
    int PageSize,
    string? SortBy,
    bool SortDesc,
    NaturalezaProcesso? Natureza,
    CategoriaProcesso? Categoria,
    StatusProcesso? Status,
    string? Search,
    int? Ano
) : IRequest<PagedResult<ProcessoDto>>;