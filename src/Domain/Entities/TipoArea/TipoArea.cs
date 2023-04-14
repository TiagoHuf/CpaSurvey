using Biopark.CpaSurvey.Domain.Models.Tipo;

namespace Biopark.CpaSurvey.Domain.Entities.TipoArea;

public partial class TipoArea : BaseEntity<long>
{
    public TipoArea(TipoAreaModel model)
    {
        Nome = model.Nome;
    }
    private TipoArea()
    {
    }

    public string Nome { get; private set; }
}