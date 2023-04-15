using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Cursos;

namespace Biopark.CpaSurvey.Domain.Entities.Cursos;

public class Curso : BaseEntity<long>, IAggregateRoot
{
    public Curso(CursoModel model)
    {
        Nome = model.Nome;
    }

    private Curso()
    {
    }

    public string Nome { get; private set; }

    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();

    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();
    private readonly List<Avaliacao> _avaliacoes = new();
}