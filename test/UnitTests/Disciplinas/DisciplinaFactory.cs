using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public class DisciplinaFactory
{
    public static DisciplinaModel GetDisciplinaNovoModel(string nome)
    {
        return new DisciplinaModel
        {
            Nome = nome
        };
    }

    public static Disciplina GetDisciplinaNova(string nome)
    {
        return new Disciplina(GetDisciplinaNovoModel(nome));
    }
}