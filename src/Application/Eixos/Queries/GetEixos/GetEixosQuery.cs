using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixoas.Queries.GetEixos;
public class GetEixosQuery : IRequest<List<Eixo>>
{
}

public class GetEixosQueryHandler :
    IRequestHandler<GetEixosQuery, List<Eixo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEixosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Eixo>> Handle(
        GetEixosQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Eixo>();

        var eixos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return eixos;
    }
}