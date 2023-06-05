namespace Biopark.CpaSurvey.Domain.Models.Avaliacoes;

public class AvaliacaoModel
{
    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public long DisciplinaId { get; set; }
}