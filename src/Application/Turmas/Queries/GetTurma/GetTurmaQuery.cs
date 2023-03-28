using Biopark.CpaSurvey.Application.Eixos.Queries.GetEixo;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Turma;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;

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

    public Task<Turma> Handler(GetTurmaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turma= repository
            .FindBy(c => c.Id == request.TurmaId)
            .Include(c => c.Curso)
            .FirstAsync(cancellationToken);

        return turma;
    }
}
