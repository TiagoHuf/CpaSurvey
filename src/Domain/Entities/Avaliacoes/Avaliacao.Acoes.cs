namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

public partial class Avaliacao
{
    public void CorrigirNomeAvaliacao(string nome)
    {
        Nome = nome;
    }

    public void CorrigirDataAvaliacao(DateTime inicio, DateTime fim)
    {
        DataInicio = inicio;
        DataFim = fim;
    }
}