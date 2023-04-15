using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Models.Eixos;

namespace Biopark.CpaSurvey.Domain.Entities.Eixos;
public partial class Eixo : BaseEntity<long>
{
    public Eixo(EixoModel model)
    {
        Nome = model.Nome;
        Descricao = model.Descricao;
    }

    private Eixo()
    {
        // Necessário para o EntityFramework.
    }

    public string Nome { get; private set; }

    public string Descricao { get; private set; }

    public IReadOnlyCollection<Pergunta> Perguntas => _perguntas.AsReadOnly();
    private readonly List<Pergunta> _perguntas = new();
}