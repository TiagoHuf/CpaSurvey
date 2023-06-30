using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverTurma;

public class RemoverTurmaCommand : IRequest
{
    public long AvaliacaoId { get; set; }

    public long TurmaId { get; set; }
}

public class RemoverTurmaCommandHandler : IRequestHandler<RemoverTurmaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverTurmaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverTurmaCommand request, CancellationToken cancellationToken)
    {
        var repositoryAvaliacao = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repositoryAvaliacao
            .FindBy(c => c.Id == request.AvaliacaoId)
            .Include(c => c.Turmas)
            .FirstAsync(cancellationToken);

        var repositoryTurma = _unitOfWork.GetRepository<Turma>();

        var turma = await repositoryTurma
            .FindBy(c => c.Id == request.TurmaId)
            .FirstAsync(cancellationToken);

        avaliacao.RemoverTurma(turma);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}