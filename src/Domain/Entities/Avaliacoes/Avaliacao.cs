using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
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
        DisciplinaId = model.DisciplinaId;
    }

    private Avaliacao()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public long DisciplinaId { get; private set; }

<<<<<<< HEAD
    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();

    public void AdicionarTurma(List<Turma> turmas)
    {
        throw new NotImplementedException();
    }
=======
    public Disciplina Disciplina { get; private set; }

    public IReadOnlyCollection<Pergunta> Perguntas => _perguntas.AsReadOnly();
    private readonly List<Pergunta> _perguntas = new();
>>>>>>> 3c8892b096853c518fd255e3381310fff743e11a
}