using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Turmas;

public class Turma : BaseEntity<long>, IAggregateRoot {
    public Turma(TurmaModel model) 
    {
        Nome = model.Nome;
        CursoId = model.CursoId;
    }

    private Turma() { 
    }

    public string Nome { get; private set; }

    public long CursoId { get; private set; }

    public Curso Curso { get; private set; }

    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();
    private readonly List<Avaliacao> _avaliacoes = new();
}