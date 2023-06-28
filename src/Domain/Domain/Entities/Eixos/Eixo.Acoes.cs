namespace Biopark.CpaSurvey.Domain.Entities.Eixos;

public partial class Eixo
{
    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }

    public void CorrigirDescricao(string descricao)
    {
        Descricao = descricao;
    }
}