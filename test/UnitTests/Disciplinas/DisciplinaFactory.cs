using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public class DisciplinaFactory
{
    public static DisciplinaModel GetDisciplinaNovoModel()
    {
        return new DisciplinaModel
        {
            Nome = "Nome Teste"
        };
    }
}