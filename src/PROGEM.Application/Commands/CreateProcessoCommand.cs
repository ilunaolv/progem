using MediatR;
using PROGEM.Domain.Enums;
using PROGEM.Domain.ValueObjects;

namespace PROGEM.Application.Commands;

public record CreateProcessoCommand(
    string Numero,
    int Ano,
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