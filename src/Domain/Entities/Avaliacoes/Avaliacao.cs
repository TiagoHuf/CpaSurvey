using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces;

namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
public partial class Avaliacao : BaseEntity<long>, IAggregateRoot
{
    public Avaliacao(AvaliacaoModel model)
    {
        
    }
    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public IReadOnlyCollection<Curso> Cursos => _cursos.AsReadOnly();
    private readonly List<Curso> _cursos = new();

    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();
}