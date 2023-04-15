using Biopark.CpaSurvey.Domain.Models.TipoArea;

namespace Biopark.CpaSurvey.Domain.Entities.TipoArea;

public partial class TipoArea : BaseEntity<long>
{
    public TipoArea(TipoAreaModel model) 
    {
        Nome = model.Nome;
    }
    private TipoArea()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }
}