using Biopark.CpaSurvey.Domain.Models.Respostas;

namespace Biopark.CpaSurvey.UnitTests.Respostas;

public class RespostaFactory
{
    public static RespostaModel GetRespostaNovaModel()
    {
        return new RespostaModel
        {
            Descricao = "Resposta teste",
            Valor = 10,
            AlunoId = 1,
            PerguntaId = 2,
        };
    }
}