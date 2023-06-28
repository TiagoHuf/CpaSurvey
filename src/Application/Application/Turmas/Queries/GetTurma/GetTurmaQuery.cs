using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Turmas.Queries.GetTurma;

public class GetTurmaQuery : IRequest<Turma>
{
    public long TurmaId { get; set; }
}

public class GetTurmaQueryHandler : IRequestHandler<GetTurmaQuery, Turma>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTurmaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Turma> Handle(GetTurmaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turma= repository
            .FindBy(c => c.Id == request.TurmaId)
            .FirstAsync(cancellationToken);

        return turma;
    }
}