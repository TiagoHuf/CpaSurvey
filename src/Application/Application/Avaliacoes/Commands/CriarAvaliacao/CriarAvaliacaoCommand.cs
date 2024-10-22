﻿using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using MediatR;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.CriarAvalicao;

public class CriarAvaliacaoCommand : IRequest<Avaliacao>
{
    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public long DisciplinaId { get; set; }
}

public class CriarAvaliacaoCommandHandler : IRequestHandler<CriarAvaliacaoCommand, Avaliacao>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarAvaliacaoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Avaliacao> Handle(CriarAvaliacaoCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var avaliacaoInserir = new Avaliacao(model);

        var repositoryAvaliacoes = _unitOfWork.GetRepository<Avaliacao>();

        repositoryAvaliacoes.Add(avaliacaoInserir);

        await _unitOfWork.CommitAsync();

        return avaliacaoInserir;
    }

    public AvaliacaoModel CriaModelo(CriarAvaliacaoCommand request)
    {
        var model = new AvaliacaoModel
        {
            Nome = request.Nome,
            DataFim = request.DataFim,
            DataInicio = request.DataInicio,
            DisciplinaId = request.DisciplinaId,
        };

        return model;
    }
}