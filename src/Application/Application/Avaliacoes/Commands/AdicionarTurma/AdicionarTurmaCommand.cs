﻿using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarTurma;

public class AdicionarTurmaCommand : IRequest
{
    public long AvaliacaoId { get; set; }

    public long TurmaId { get; set; }
}

public class AdicionarTurmaCommandHandler : IRequestHandler<AdicionarTurmaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarTurmaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AdicionarTurmaCommand request, CancellationToken cancellationToken)
    {
        var repositoryAvaliacao = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repositoryAvaliacao
            .FindBy(c => c.Id == request.AvaliacaoId)
            .FirstAsync(cancellationToken);

        var repositoryTurma = _unitOfWork.GetRepository<Turma>();

        var turma = await repositoryTurma
            .FindBy(c => c.Id == request.TurmaId)
            .FirstAsync(cancellationToken);

        avaliacao.AdicionarTurma(turma);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}