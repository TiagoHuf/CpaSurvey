using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;

public class GetPerguntaQuery : IRequest<Pergunta>
{
    public long PerguntaId { get; set; }
}

public class GetPerguntaQueryHandler : IRequestHandler<GetPerguntaQuery, Pergunta>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPerguntaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Pergunta> Handle(GetPerguntaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Pergunta>();

        var pergunta = repository
            .FindBy(c => c.Id == request.PerguntaId)
            .Include(c => c.Eixo)
            .FirstAsync(cancellationToken);

        return pergunta;
    }
}