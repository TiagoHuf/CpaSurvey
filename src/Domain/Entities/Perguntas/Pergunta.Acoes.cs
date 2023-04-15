using Biopark.CpaSurvey.Domain.Entities.Eixos;

namespace Biopark.CpaSurvey.Domain.Entities.Perguntas;

public partial class Pergunta
{
    private void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }

    private void CorrigirTipoResposta(TipoResposta tipo)
    {
        TipoResposta = tipo;
    }

    private void CorrigirEixo(Eixo eixo)
    {
        Eixo = eixo;
    }
}