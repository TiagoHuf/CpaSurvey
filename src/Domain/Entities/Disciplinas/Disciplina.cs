using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.Domain.Entities.Disciplinas;

public partial class Disciplina : BaseEntity<long>
{
    public Disciplina(DisciplinaModel model) 
    { 
        Nome = model.Nome;
    }

    private Disciplina()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }
}