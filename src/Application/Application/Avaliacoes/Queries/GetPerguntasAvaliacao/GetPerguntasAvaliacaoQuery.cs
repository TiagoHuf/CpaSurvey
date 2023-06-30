using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetPerguntasAvaliacao;

public class GetPerguntasAvaliacaoQuery : IRequest<List<PerguntasAvaliacaoModelView>>
{
    public long AvaliacaoId { get; set; }
}

public class GetPerguntasAvaliacaoQueryHandler : IRequestHandler<GetPerguntasAvaliacaoQuery, List<PerguntasAvaliacaoModelView>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPerguntasAvaliacaoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PerguntasAvaliacaoModelView>> Handle(GetPerguntasAvaliacaoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repository
            .FindBy(c => c.Id == request.AvaliacaoId)
            .Include(a => a.Perguntas)
            .FirstAsync(cancellationToken);

        var perguntaRepository = _unitOfWork.GetRepository<Pergunta>();

        var perguntas = await perguntaRepository
            .GetAll()
            .Include(p => p.Eixo)
            .ToListAsync(cancellationToken);

        List<PerguntasAvaliacaoModelView> perguntasView = new ();

        foreach(Pergunta perguntaAll in perguntas)
        {
            var perguntaNova = new PerguntasAvaliacaoModelView
            {
                Id = perguntaAll.Id,
                Descricao = perguntaAll.Descricao,
                TipoResposta = perguntaAll.TipoResposta,
                Eixo = perguntaAll.Eixo.Nome,
                IsNaAvaliacao = false,
            };

            foreach (Pergunta perguntaAvaliacao in avaliacao.Perguntas)
            {
                if (perguntaAll.Id == perguntaAvaliacao.Id)
                {
                    perguntaNova.IsNaAvaliacao = true;
                    break;
                }
            }

            perguntasView.Add(perguntaNova);
        }

        return perguntasView;
    }
}