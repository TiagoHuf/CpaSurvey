using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
public class RemoverPerguntaCommand : IRequest
{
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
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = await repository
            .FindBy(c => c.Id == request.PerguntaId)
            .FirstAsync(cancellationToken);

        repository.Delete(pergunta);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}