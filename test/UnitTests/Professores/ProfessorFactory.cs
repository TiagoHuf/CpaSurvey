
using Biopark.CpaSurvey.Domain.Models.Professores;

namespace Biopark.CpaSurvey.UnitTests.Professores;

public class ProfessorFactory
{
    public static ProfessorModel GetProfessorNovoModel()
    {
        return new ProfessorModel
        {
            Nome = "Professor Teste"
        };
    }
}