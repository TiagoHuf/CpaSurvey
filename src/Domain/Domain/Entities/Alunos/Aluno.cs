using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Alunos;

namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno : BaseEntity<long>, IAggregateRoot
{
    public Aluno(AlunoModel model)
    {
        Nome = model.Nome;
        Ra = model.Ra;
        Email = model.Email;
        CursoId = model.CursoId;
        IsAtivo = true;
    }

    private Aluno()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public string Ra { get; private set; }
    
    public string Email { get; private set; }

    public bool IsAtivo { get; private set; }

    public long CursoId { get; private set; }

    public Curso Curso { get; private set; }

    public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();
    private readonly List<Resposta> _respostas = new();

    public IReadOnlyCollection<AlunoDisciplina> Disciplinas => _disciplinas.AsReadOnly();
    private readonly List<AlunoDisciplina> _disciplinas = new();

    public IReadOnlyCollection<Turma> Turmas => _turmas.AsReadOnly();
    private readonly List<Turma> _turmas = new();
}