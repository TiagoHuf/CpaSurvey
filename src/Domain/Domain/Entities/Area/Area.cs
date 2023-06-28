using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Tipo;

namespace Biopark.CpaSurvey.Domain.Entities.Area;
public class Area : BaseEntity<long>, IAggregateRoot
{
    public Area(TipoAreaModel model)
    {
        Nome = model.Nome;
        TipoArea = model.TipoArea;
    }

    private Area()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public TipoArea TipoArea { get; private set; }

    public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();
    private readonly List<Resposta> _respostas = new();
}
