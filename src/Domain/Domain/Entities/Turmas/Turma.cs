using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Turmas;

public partial class Turma : BaseEntity<long>, IAggregateRoot
{
    public Turma(TurmaModel model) 
    {
        Nome = model.Nome;
        CursoId = model.CursoId;
    }

    private Turma() 
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public long CursoId { get; private set; }

    public Curso Curso { get; private set; }

    public IReadOnlyCollection<Disciplina> Disciplinas => _disciplinas.AsReadOnly();
    private readonly List<Disciplina> _disciplinas = new();

    public IReadOnlyCollection<Aluno> Alunos => _alunos.AsReadOnly();
    private readonly List<Aluno> _alunos = new();
}