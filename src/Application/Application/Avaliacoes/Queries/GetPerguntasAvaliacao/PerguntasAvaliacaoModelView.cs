using Biopark.CpaSurvey.Domain.Entities.Perguntas;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetPerguntasAvaliacao;

public class PerguntasAvaliacaoModelView
{
    public long Id { get; set; }

    public string Descricao { get; set; }

    public TipoResposta TipoResposta { get; set; }

    public bool IsNaAvaliacao { get; set; }

    public string Eixo { get; set; }
}