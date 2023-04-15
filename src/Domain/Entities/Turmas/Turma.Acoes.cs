using Biopark.CpaSurvey.Domain.Entities.Cursos;

namespace Biopark.CpaSurvey.Domain.Entities.Turmas;

public partial class Turma
{
    public void CorrigirNomeTurma(string nome)
    {
        Nome = nome;
    }

    public void CorrigirCursoTurma(Curso curso)
    {
        Curso = curso;
    }
}