using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Respostas.Queries.GetRespostas;

public class GetRespostasQuery : IRequest<List<Resposta>>
{
}

public class GetRespostasQueryHandler :
    IRequestHandler<GetRespostasQuery, List<Resposta>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRespostasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Resposta>> Handle(
        GetRespostasQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Resposta>();

        var Respostas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return Respostas;
    }
}