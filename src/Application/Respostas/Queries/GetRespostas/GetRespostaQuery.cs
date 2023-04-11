using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Queries.GetResposta;
public class GetRespostaQuery : IRequest<Resposta>
{
    public long RespostaId { get; set; }
}

public class GetRespostaQueryHandler : IRequestHandler<GetRespostaQuery, Resposta>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRespostaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Resposta> Handle(GetRespostaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Resposta>();

        var Resposta = repository
            .FindBy(c => c.Id == request.RespostaId)
            .Include(c => c.Pergunta)
            .Include(c => c.Aluno)
            .FirstAsync(cancellationToken);

        return Resposta;
    }
}