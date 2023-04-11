using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverAvaliacao;

public class RemoverAvaliacaoCommand : IRequest
{
    public long AvaliacaoId { get; set; }
}

public class RemoverAvaliacaoCommandHandler : IRequestHandler<RemoverAvaliacaoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverAvaliacaoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverAvaliacaoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repository
            .FindBy(c => c.Id == request.AvaliacaoId)
            .FirstAsync(cancellationToken);

        repository.Delete(avaliacao);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}