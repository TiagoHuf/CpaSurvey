using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Perguntas;
using MediatR;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
public class CriarPerguntaCommand : IRequest<Pergunta>
{
    public string Descricao { get; set; }

    public TipoResposta TipoResposta { get; set; }

    public long EixoId { get; set; }
}

public class CriarPerguntaCommandHandler : IRequestHandler<CriarPerguntaCommand, Pergunta>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CriarPerguntaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }   

    public async Task<Pergunta> Handle(CriarPerguntaCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var perguntaInserir = new Pergunta(model);

        var repositoryPergunta = _unitOfWork.GetRepository<Pergunta>();

        repositoryPergunta.Add(perguntaInserir);

        await _unitOfWork.CommitAsync();

        return perguntaInserir;   
    }

    public PerguntaModel CriaModelo(CriarPerguntaCommand request)
    {
        var model = new PerguntaModel
        {
            Descricao = request.Descricao,
            TipoResposta = request.TipoResposta,
            EixoId = request.EixoId,
        };

        return model;
    }
}