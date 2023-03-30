using Biopark.CpaSurvey.Domain.Models.Tipo;

namespace Biopark.CpaSurvey.Domain.Entities.Tipo;

public partial class Tipo : BaseEntity<long>
{
    public Tipo(TipoModel model) 
    {
        Nome = model.Nome;
    }
    private Tipo()
    {
    }

    public string Nome { get; private set; }
}