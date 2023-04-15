using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirTipoResposta;

public class CorrigirTipoRespostaPerguntaCommand : IRequest
{
    public long PerguntaId { get; set; }

    public TipoResposta TipoResposta { get; set; }
}

public class CorrigirTipoRespostaPerguntaCommandHandler : IRequestHandler<CorrigirTipoRespostaPerguntaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirTipoRespostaPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirTipoRespostaPerguntaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repository
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        pergunta.CorrigirTipoResposta(request.TipoResposta);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}