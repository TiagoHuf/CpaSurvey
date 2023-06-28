using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Professores.Queries.GetProfessor;

public class GetProfessorQuery : IRequest<Professor>
{
    public long ProfessorId { get; set; }
}

public class GetProfessorQueryHandler : IRequestHandler<GetProfessorQuery, Professor>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProfessorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Professor> Handle(GetProfessorQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Professor>();

        var professor = repository
            .FindBy(c => c.Id == request.ProfessorId)
            .FirstAsync(cancellationToken);

        return professor;
    }
}