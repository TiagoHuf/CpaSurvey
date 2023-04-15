using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Perguntas;

namespace Biopark.CpaSurvey.Domain.Entities.Perguntas;
public partial class Pergunta : BaseEntity<long>, IAggregateRoot
{
    public Pergunta(PerguntaModel model)
    {
        Descricao = model.Descricao;
        TipoResposta = model.TipoResposta;
        EixoId = model.EixoId;
    }

    private Pergunta()
    {
        // Necessário para o EntityFramework.
    }

    public string Descricao { get; private set; }

    public TipoResposta TipoResposta { get; private set; }

    public long EixoId { get; private set; }

    public Eixo Eixo { get; private set; }

    public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();
    private readonly List<Resposta> _respostas = new();
}