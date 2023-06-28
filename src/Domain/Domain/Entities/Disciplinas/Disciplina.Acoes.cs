namespace Biopark.CpaSurvey.Domain.Entities.Disciplinas;

public partial class Disciplina
{
    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }
}