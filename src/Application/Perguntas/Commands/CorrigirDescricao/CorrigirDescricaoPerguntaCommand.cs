using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;

public class CorrigirDescricaoPerguntaCommand : IRequest
{
    public long PerguntaId { get; set; }

    public string Descricao { get; set; }
}

public class CorrigirDescricaoPerguntaCommandHandler : IRequestHandler<CorrigirDescricaoPerguntaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirDescricaoPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirDescricaoPerguntaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repository
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        pergunta.CorrigirDescricao(request.Descricao);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}