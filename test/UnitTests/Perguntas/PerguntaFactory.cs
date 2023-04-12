using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Models.Perguntas;

namespace Biopark.CpaSurvey.UnitTests.Perguntas;
public class PerguntaFactory
{
    public static PerguntaModel GetPerguntaNovaModel()
    {
        return new PerguntaModel
        {
            Descricao = "Pergunta teste",
            EixoId = 1,
            TipoResposta = TipoResposta.Descritiva,
        };
    }
}