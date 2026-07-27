using MediatR;
using PROGEM.Domain.Enums;

namespace PROGEM.Application.Commands;

public record UpdateProcessoCommand(
    Guid Id,
    string? Codigo,
    string? Anexo,
    string? Volume,
    NaturalezaProcesso Natureza,
    CategoriaProcesso Categoria,
    SubcategoriaProcesso Subcategoria,
    string Requerente,
    string Local,
    TipoProcesso Tipo,
    string Assunto,
    DateTime DataIrregularidade,
    string? Observacoes
) : IRequest<ProcessoDto>;