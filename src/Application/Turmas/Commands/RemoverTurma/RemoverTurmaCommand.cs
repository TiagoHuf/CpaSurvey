using Biopark.CpaSurvey.Domain.Entities.Turma;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.RemoverTurma;

public class RemoverTurmaCommand : IRequest
{
    public long TurmaId { get; set; }
}

public class RemoverTurmaCommandHandler : IRequestHandler<RemoverTurmaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverTurmaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handler(RemoverTurmaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turma = await repository
            .FindBy(c => c.Id == request.TurmaId)
            .FirstAsync(cancellationToken);

        repository.Delete(turma);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}