using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.CorrigirNome;

public class CorrigirNomeTurmaCommand : IRequest
{
    public long TurmaId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeTurmaCommandHandler : IRequestHandler<CorrigirNomeTurmaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeTurmaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeTurmaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turma = await repository
            .FindBy(c => c.Id == request.TurmaId)
            .FirstAsync(cancellationToken);

        turma.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}