using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Models.Turmas;

namespace Biopark.CpaSurvey.UnitTests.Turmas;

public class TurmaFactory
{
    public static TurmaModel GetTurmaNovaModel(string nome)
    {
        return new TurmaModel
        {
            Nome = nome,
            CursoId = 1,
        };
    }

    public static Turma GetTurmaNova(string nome)
    {
        return new Turma(GetTurmaNovaModel(nome));
    }
}