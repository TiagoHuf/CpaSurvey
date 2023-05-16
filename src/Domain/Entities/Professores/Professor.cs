using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Models.Professores;

namespace Biopark.CpaSurvey.Domain.Entities.Professores;

public partial class Professor : BaseEntity<long>
{
    public Professor(ProfessorModel model)
    {
        Nome = model.Nome;
    }

    private Professor()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; set; }

    public IReadOnlyCollection<Disciplina> Disciplinas => _disciplinas.AsReadOnly();
    private readonly List<Disciplina> _disciplinas = new();
}