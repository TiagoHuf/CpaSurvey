using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Alunos;

namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno : BaseEntity<long>, IAggregateRoot
{
    public Aluno(AlunoModel model)
    {
        Nome = model.Nome;
        Ra = model.Ra;
        IsAtivo = true;
    }

    private Aluno()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public string Ra { get; private set; }

    public bool IsAtivo { get; private set; }

    public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();
    private readonly List<Resposta> _respostas = new();
}
