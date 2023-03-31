using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplina;
public class GetDisciplinaQuery : IRequest<Disciplina>
{
    public long DisciplinaId { get; set; }
}

public class GetDisciplinaQueryHandler : IRequestHandler<GetDisciplinaQuery, Disciplina>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDisciplinaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Disciplina> Handle(GetDisciplinaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Disciplina>();

        var disciplina = repository
            .FindBy(c => c.Id == request.DisciplinaId)
            .FirstAsync(cancellationToken);

        return disciplina;
    }
}