using MediatR;
using PROGEM.Shared;

namespace PROGEM.Application.Queries;

public record GetDashboardQuery() : IRequest<DashboardData>;

public record GetRelatorioProcessosQuery(
    int Page,
    int PageSize,
    string? SortBy,
    bool SortDesc,
    DateTime? DataInicio,
    DateTime? DataFim,
    NaturalezaProcesso? Natureza,
    CategoriaProcesso? Categoria,
    StatusProcesso? Status,
    string? Secretaria,
    string? servidorNome
) : IRequest<PagedResult<ProcessoDto>>;