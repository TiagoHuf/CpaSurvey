using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;

namespace Biopark.CpaSurvey.Domain.Entities;

public class AlunoDisciplina : BaseEntity<long>
{
    public long AlunoId { get; set; }

    public bool IsRespondido { get; set; }

    public long DisciplinaId { get; set; }

    public Aluno Aluno { get; set; }

    public Disciplina Disciplina { get; set; }
}