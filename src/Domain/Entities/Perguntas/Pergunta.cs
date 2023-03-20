using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Perguntas;

namespace Biopark.CpaSurvey.Domain.Entities.Perguntas;
public class Pergunta : BaseEntity<long>, IAggregateRoot
{
    public Pergunta(PerguntaModel model)
    {
        Descricao = model.Descricao;
        TipoResposta = model.TipoResposta;
        EixoId = model.EixoId;
    }

    private Pergunta()
    {   
    }

    public string Descricao { get; private set; }

    public TipoResposta TipoResposta { get; private set; }

    public long EixoId { get; private set; }

    public Eixo Eixo { get; private set; }
}