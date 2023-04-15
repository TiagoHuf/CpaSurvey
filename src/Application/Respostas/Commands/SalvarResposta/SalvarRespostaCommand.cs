using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Respostas;
using MediatR;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;

public class SalvarRespostaCommand : IRequest<Resposta>
{
    public string Descricao { get; set; }

    public int Valor { get; set; }

    public long PerguntaId { get; set; }

    public long AlunoId { get; set; } 
}

public class SalvarResposaCommandHandler : IRequestHandler<SalvarRespostaCommand, Resposta>
{
    private readonly IUnitOfWork _unitOfWork;

    public SalvarResposaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(SalvarRespostaCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var RespostaInserir = new Resposta(model);

        var repositoryResposta = _unitOfWork.GetRepository<Resposta>();

        repositoryResposta.Add(RespostaInserir);

        await _unitOfWork.CommitAsync();

        return RespostaInserir;
    }

    public RespostaModel CriaModelo(SalvarRespostaCommand request)
    {
        var model = new RespostaModel
        {
            Descricao = request.Descricao,
            Valor = request.Valor,
            PerguntaId = request.PerguntaId,
            AlunoId = request.AlunoId,
        };

        return model;
    }
}  

