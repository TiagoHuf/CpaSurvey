using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Models.Cursos;


namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoFactory
{
    public static CursoModel GetCursoNovoModel(string nome)
    {
        return new CursoModel
        {
            Nome = nome
        };
    }

    public static Curso GetCursoNovo(string nome)
    {
        return new Curso(GetCursoNovoModel(nome));
    }
}