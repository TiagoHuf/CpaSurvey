namespace Biopark.CpaSurvey.Domain.Entities.Eixos;

public partial class Eixo
{
    private void CorrigirNome(string nome)
    {
        Nome = nome;
    }

    private void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }
}