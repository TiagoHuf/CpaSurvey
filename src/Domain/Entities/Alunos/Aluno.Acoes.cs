using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno
{
    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }

    public void CorrigirRa(string ra)
    {
        Ra = ra;
    }

    public void Ativar()
    {
        IsAtivo = true;
    }

    public void Inativar()
    {
        IsAtivo = false;
    }

    public void AdicionarDisciplina(Disciplina disciplina)
    {
        var alunoDisciplina = new AlunoDisciplina
        {
            Aluno = this,
            Disciplina = disciplina
        };

        _disciplinas.Add(alunoDisciplina);
    }

    public void AdicionarTurma(Turma turma)
    {
        _turmas.Add(turma);
    }
}