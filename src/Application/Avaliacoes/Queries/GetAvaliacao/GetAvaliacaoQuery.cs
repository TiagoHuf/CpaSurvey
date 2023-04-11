using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetAvaliacao;

public class GetAvaliacaoQuery : IRequest<Avaliacao>
{
    public long AvaliacaoId { get; set; }
}

public class GetAvaliacaoQueryHandler : IRequestHandler<GetAvaliacaoQuery, Avaliacao>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAvaliacaoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Avaliacao> Handle(GetAvaliacaoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = repository
            .FindBy(c => c.Id == request.AvaliacaoId)
            .FirstAsync(cancellationToken);

        return avaliacao;
    }
}