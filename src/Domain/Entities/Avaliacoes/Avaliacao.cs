using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Avaliacoes;

namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
public partial class Avaliacao : BaseEntity<long>, IAggregateRoot
{
    public Avaliacao(AvaliacaoModel model)
    {
        Nome = model.Nome;
        DataInicio = model.DataInicio;
        DataFim = model.DataFim;
        CursoId = model.CursoId;
        TurmaId = model.TurmaId;

        foreach (var item in model.Cursos)
        {
            _cursos.Add(item);
        }

        foreach (var item in model.Turmas)
        {
            _turmas.Add(item);
        }
    }

    private Avaliacao()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public long CursoId { get; private set; }

    public long TurmaId { get; private set; }

    public IReadOnlyCollection<Curso> Cursos => _cursos.AsReadOnly();
    private readonly List<Curso> _cursos = new();

    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();
}