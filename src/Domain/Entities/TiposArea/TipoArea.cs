using Biopark.CpaSurvey.Domain.Models.TiposArea;

namespace Biopark.CpaSurvey.Domain.Entities.TiposArea;

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