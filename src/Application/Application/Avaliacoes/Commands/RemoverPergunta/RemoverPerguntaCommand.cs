using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverPergunta;

public class RemoverPerguntaCommand : IRequest
{
    public long AvaliacaoId { get; set; }

    public long PerguntaId { get; set; }
}

public class RemoverPerguntaCommandHandler : IRequestHandler<RemoverPerguntaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverPerguntaCommand request, CancellationToken cancellationToken)
    {
        var repositoryAvaliacao = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repositoryAvaliacao
            .FindBy(c => c.Id == request.AvaliacaoId)
            .Include(c => c.Perguntas)
            .FirstAsync(cancellationToken);

        var repositoryPergunta = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repositoryPergunta
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        avaliacao.RemoverPergunta(pergunta);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}