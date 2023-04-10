using Biopark.CpaSurvey.Domain.Models.Alunos;

namespace Biopark.CpaSurvey.UnitTests.Alunos;

public class AlunoFactory
{
    public static AlunoModel GetAlunoNovoModel()
    {
        return new AlunoModel
        {
            Nome = "João da Silva",
            Ra = "555",
        };
    }
}