using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

public partial class Avaliacao
{
    private void CorrigirNomeAvaliacao(string nome)
    {
        Nome = nome;
    }

    private void CorrigirDataAvaliacao(DateTime inicio, DateTime fim)
    {
        DataInicio = inicio;
        DataFim = fim;
    }

    private void RemoverCurso(Curso curso)
    {
        _cursos.Remove(curso);
    }

    private void  AdicionarCurso(Curso curso)
    {
        _cursos.Add(curso);
    }

    private void AdicionarTurma(Turma turma)
    {
        _turmas.Add(turma);
    }

    private void RemoverTurma(Turma turma)
    {
        _turmas.Remove(turma);
    }
}