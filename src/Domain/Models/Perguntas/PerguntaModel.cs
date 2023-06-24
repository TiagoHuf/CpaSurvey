using Biopark.CpaSurvey.Domain.Entities.Perguntas;

namespace Biopark.CpaSurvey.Domain.Models.Perguntas;
public class PerguntaModel
{
    public string Descricao { get; set; }

    public TipoResposta TipoResposta { get; set; }

    public long EixoId { get; set; }
}