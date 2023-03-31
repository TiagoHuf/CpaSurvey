using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Disciplinas.Queries.GetDisciplinas;
public class GetDisciplinasQuery : IRequest<List<Disciplina>>
{
}

public class GetDisciplinasQueryHandler :
    IRequestHandler<GetDisciplinasQuery, List<Disciplina>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDisciplinasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Disciplina>> Handle(
        GetDisciplinasQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Disciplina>();

        var Disciplinas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return Disciplinas;
    }
}