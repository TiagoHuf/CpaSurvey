using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Turma;

namespace Biopark.CpaSurvey.Domain.Entities.Turma;

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

    public Curso curso { get; private set; }
}
