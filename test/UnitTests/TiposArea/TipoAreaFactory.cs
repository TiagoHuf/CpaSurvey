using Biopark.CpaSurvey.Domain.Models.TiposArea;

namespace Biopark.CpaSurvey.UnitTests.TiposArea;

public class TipoAreaFactory
{
    public static TipoAreaModel GetTipoAreaNovaModel()
    {
        return new TipoAreaModel
        {
            Nome = "Nova Area",
        };
    }
}