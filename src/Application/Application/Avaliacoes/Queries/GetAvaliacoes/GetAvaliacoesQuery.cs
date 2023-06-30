using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacoes;

public class GetAvaliacoesQuery : IRequest<List<Avaliacao>>
{
}

public class GetAvaliacoesQueryHandler :
    IRequestHandler<GetAvaliacoesQuery, List<Avaliacao>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAvaliacoesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Avaliacao>> Handle(
        GetAvaliacoesQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacoes = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return avaliacoes;
    }
}