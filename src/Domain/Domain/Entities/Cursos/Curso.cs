using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Cursos;

namespace Biopark.CpaSurvey.Domain.Entities.Cursos;

public partial class Curso : BaseEntity<long>, IAggregateRoot
{
    public Curso(CursoModel model)
    {
        Nome = model.Nome;
    }

    private Curso()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();

    public IReadOnlyCollection<Disciplina> Disciplinas => _disciplinas.AsReadOnly();
    private readonly List<Disciplina> _disciplinas = new();

    public IReadOnlyCollection<Aluno> Alunos => _alunos.AsReadOnly();
    private readonly List<Aluno> _alunos = new();
}