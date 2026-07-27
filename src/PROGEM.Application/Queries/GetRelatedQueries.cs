using MediatR;
using PROGEM.Shared;

namespace PROGEM.Application.Queries;

public record GetEnvolvidosByProcessoQuery(Guid ProcessoId) : IRequest<List<EnvolvidoDto>>;

public record GetTramitacoesByProcessoQuery(Guid ProcessoId) : IRequest<List<TramitacaoDto>>;

public record GetProrrogacoesByProcessoQuery(Guid ProcessoId) : IRequest<List<ProrrogacaoDto>>;

public record GetHistoricoByProcessoQuery(Guid ProcessoId) : IRequest<List<HistoricoDto>>;