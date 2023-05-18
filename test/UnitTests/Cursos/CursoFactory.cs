using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Models.Cursos;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoFactory
{
    public static CursoModel GetCursoNovoModel()
    {
        return new CursoModel
        {
            Nome = "Curso teste"
        };
    }
}