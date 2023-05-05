using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Models.Cursos;
using FluentAssertions.Equivalency;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoFactory
{
    public static CursoModel GetCursoNovoModel()
    {
        return new CursoModel
        {
            Nome = "Analise e Desenvolvimento de Sistemas",
        };
    }
}