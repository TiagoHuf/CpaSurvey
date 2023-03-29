using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Alunos;

namespace Biopark.CpaSurvey.Domain.Entities.Usuarios;
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

    public string Nome { get; set; }

    public string Ra { get; set; }

    public bool IsAtivo { get; set; }

    public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();
    private readonly List<Resposta> _respostas = new();
}
