namespace Biopark.CpaSurvey.Domain.Entities.Perguntas;

public partial class Pergunta
{
    public void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }

    public void CorrigirTipoResposta(TipoResposta tipo)
    {
        TipoResposta = tipo;
    }

    public void CorrigirEixo(long eixoId)
    {
        EixoId = eixoId;
    }
}