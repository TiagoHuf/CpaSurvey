using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.Domain.Entities.Disciplinas;

public partial class Disciplina : BaseEntity<long>
{
    public Disciplina(DisciplinaModel model) 
    { 
        Nome = model.Nome;
        ProfessorId = model.ProfessorId;
        CursoId = model.CursoId;
    }

    private Disciplina()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public long ProfessorId { get; private set; }

    public long CursoId { get; private set; }

    public Professor Professor { get; private set; }

    public Curso Curso { get; private set; }

    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();
    private readonly List<Avaliacao> _avaliacoes = new();

    public IReadOnlyCollection<AlunoDisciplina> Alunos => _alunos.AsReadOnly();
    private readonly List<AlunoDisciplina> _alunos = new();
}