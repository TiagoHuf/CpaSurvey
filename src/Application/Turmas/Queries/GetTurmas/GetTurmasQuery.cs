using Biopark.CpaSurvey.Domain.Entities.Turma;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Turmas.Queries.GetTurmas;

public class GetTurmasQuery : IRequest<List<Turma>>
{

}

public class GetTurmasQueryHandler : IRequestHandler<GetTurmasQuery, List<Turma>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTurmasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Turma>> Handle(GetTurmasQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Turma>();

        var turmas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return turmas;
    }
}