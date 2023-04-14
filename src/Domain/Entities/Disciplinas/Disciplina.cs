using Biopark.CpaSurvey.Domain.Models.Disciplinas;

namespace Biopark.CpaSurvey.Domain.Entities.Disciplinas;

public class Disciplina : BaseEntity<long>
{
    public Disciplina(DisciplinaModel model) 
    { 
        Nome = model.Nome;
    }

    private Disciplina() { }

    public string Nome { get; private set; }
}