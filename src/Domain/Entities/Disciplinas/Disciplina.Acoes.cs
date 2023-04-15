namespace Biopark.CpaSurvey.Domain.Entities.Disciplinas;

public partial class Disciplina
{
    public void CorrigirNomeDisciplina(string nome)
    {
        Nome = nome;
    }
}