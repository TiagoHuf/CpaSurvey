using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Queries.GetPerguntas;

public class GetPerguntasQuery : IRequest<List<Pergunta>>
{
}

public class GetPerguntasQueryHandler :
    IRequestHandler<GetPerguntasQuery, List<Pergunta>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPerguntasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Pergunta>> Handle(
        GetPerguntasQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var perguntas = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return perguntas;
    }
}