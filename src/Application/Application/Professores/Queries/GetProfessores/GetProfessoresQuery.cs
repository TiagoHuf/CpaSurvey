using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Professores.Queries.GetProfessor;

public class GetProfessoresQuery : IRequest<List<Professor>>
{
}

public class GetProfessoresQueryHandler :
    IRequestHandler<GetProfessoresQuery, List<Professor>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProfessoresQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Professor>> Handle(
        GetProfessoresQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Professor>();

        var professores = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return professores;
    }
}