using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Queries.Getrespostas;
public class GetRespostaQuery : IRequest<List<Resposta>>
{
}

public class GetRespostasQueryHandler :
    IRequestHandler<GetRespostaQuery, List<Resposta>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRespostasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Resposta>> Handle(
        GetRespostaQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Resposta>();

        var Respostas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return Respostas;
    }
}
