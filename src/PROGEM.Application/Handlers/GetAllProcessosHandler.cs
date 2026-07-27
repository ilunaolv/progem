using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Enums;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class GetAllProcessosHandler : IRequestHandler<GetAllProcessosQuery, PagedResult<ProcessoDto>>
{
    private readonly IProcessoRepository _processoRepository;
    private readonly IMapper _mapper;

    public GetAllProcessosHandler(IProcessoRepository processoRepository, IMapper mapper)
    {
        _processoRepository = processoRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<ProcessoDto>> Handle(GetAllProcessosQuery request, CancellationToken cancellationToken)
    {
        var processos = await _processoRepository.GetAllAsync(cancellationToken);

        var query = processos.AsQueryable();

        if (request.Natureza.HasValue)
            query = query.Where(p => p.Natureza == request.Natureza.Value);
        if (request.Categoria.HasValue)
            query = query.Where(p => p.Categoria == request.Categoria.Value);
        if (request.Status.HasValue)
            query = query.Where(p => p.Status == request.Status.Value);
        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(p => p.Numero.Valor.Contains(request.Search, StringComparison.OrdinalIgnoreCase)
                || p.Requerente.Contains(request.Search, StringComparison.OrdinalIgnoreCase)
                || p.Assunto.Contains(request.Search, StringComparison.OrdinalIgnoreCase));
        if (request.Ano.HasValue)
            query = query.Where(p => p.Ano == request.Ano.Value);

        query = request.SortBy?.ToLower() switch
        {
            "numerro" or "numero" => request.SortDesc ? query.OrderByDescending(p => p.Numero.Valor) : query.OrderBy(p => p.Numero.Valor),
            "data" or "criadoem" => request.SortDesc ? query.OrderByDescending(p => p.CriadoEm) : query.OrderBy(p => p.CriadoEm),
            _ => request.SortDesc ? query.OrderByDescending(p => p.CriadoEm) : query.OrderBy(p => p.CriadoEm)
        };

        var totalCount = query.Count();
        var items = query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<ProcessoDto>
        {
            Items = _mapper.Map<List<ProcessoDto>>(items),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}