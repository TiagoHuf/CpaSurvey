using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces;

namespace Biopark.CpaSurvey.Domain.Entities.Respostas;
public class Resposta : BaseEntity<long>, IAggregateRoot
{
    private Resposta()
    {
        // Necessário para o EntityFramework.
    }
    public string? Descricao { get; set; }

    public int? Valor { get; set; }

    public long PerguntaId { get; set; }

    public long AlunoId { get; set; }

    public Aluno Aluno { get; set; }

    public Pergunta Pergunta { get; set; }
}