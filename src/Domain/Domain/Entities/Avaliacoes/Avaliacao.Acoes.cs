namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

public partial class Avaliacao
{
    public void CorrigirNomeAvaliacao(string nome)
    {
        Nome = nome;
    }

    public void CorrigirDataAvaliacao(DateTime fim)
    {
        DataFim = fim;
    }
}