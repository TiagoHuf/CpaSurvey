namespace Biopark.CpaSurvey.Domain.Entities.Respostas;

public partial class Resposta
{
    private void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }

    private void CorrigirValor(int valor)
    {
        Valor = valor;
    }
}