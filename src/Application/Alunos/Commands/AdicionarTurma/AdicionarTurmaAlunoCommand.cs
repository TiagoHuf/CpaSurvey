using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarTurma;

public class AdicionarTurmaAlunoCommand : IRequest
{
    public long AlunoId { get; set; }

    public long TurmaId { get; set; }
}

public class AdicionarTurmaAlunoCommandHandler : IRequestHandler<AdicionarTurmaAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarTurmaAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AdicionarTurmaAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        var turma = await BuscaTurma(request.TurmaId, cancellationToken);

        aluno.AdicionarTurma(turma);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }

    public async Task<Turma> BuscaTurma(long id, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turma = await repository
           .FindBy(c => c.Id == id)
           .FirstAsync(cancellationToken);

        return turma;
    }
}