using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirEixo;

public class CorrigirEixoPerguntaCommand : IRequest
{
    public long PerguntaId { get; set; }

    public long EixoId { get; set; }
}

public class CorrigirEixoPerguntaCommandHandler : IRequestHandler<CorrigirEixoPerguntaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirEixoPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirEixoPerguntaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repository
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        pergunta.CorrigirEixo(request.EixoId);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}