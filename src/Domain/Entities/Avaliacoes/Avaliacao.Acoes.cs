using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

public partial class Avaliacao
{
    public void CorrigirNomeAvaliacao(string nome)
    {
        Nome = nome;
    }

    public void CorrigirDataAvaliacao(DateTime inicio, DateTime fim)
    {
        DataInicio = inicio;
        DataFim = fim;
    }

    public void RemoverCurso(Curso curso)
    {
        _cursos.Remove(curso);
    }

    public void  AdicionarCurso(Curso curso)
    {
        _cursos.Add(curso);
    }

    public void AdicionarTurma(Turma turma)
    {
        _turmas.Add(turma);
    }

    public void RemoverTurma(Turma turma)
    {
        _turmas.Remove(turma);
    }
}