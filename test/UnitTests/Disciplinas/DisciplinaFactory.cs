using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public class DisciplinaFactory
{
    public static DisciplinaModel GetDisciplinaNovaModel(string nome)
    {
        return new DisciplinaModel
        {
            Nome = nome,
            ProfessorId = 1,
            CursoId = 1
        };
    }

    public static Disciplina GetDisciplinaNova(string nome)
    {
        return new Disciplina(GetDisciplinaNovaModel(nome));
    }
}