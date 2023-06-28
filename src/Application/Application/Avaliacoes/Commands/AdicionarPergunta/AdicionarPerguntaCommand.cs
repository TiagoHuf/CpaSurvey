using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarPergunta;

public class AdicionarPerguntaCommand : IRequest
{
    public long AvaliacaoId { get; set; }

    public long PerguntaId { get; set; }
}

public class AdicionarPerguntaCommandHandler : IRequestHandler<AdicionarPerguntaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AdicionarPerguntaCommand request, CancellationToken cancellationToken)
    {
        var repositoryAvaliacao = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repositoryAvaliacao
            .FindBy(c => c.Id == request.AvaliacaoId)
            .FirstAsync(cancellationToken);

        var repositoryPergunta = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repositoryPergunta
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        avaliacao.AdicionarPergunta(pergunta);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}