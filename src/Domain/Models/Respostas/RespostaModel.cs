using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;

namespace Biopark.CpaSurvey.Domain.Models.Respostas;
public class RespostaModel
{
    public string? Descricao { get; set; }

    public int? Valor { get; set; }

    public long PerguntaId { get; set; }

    public long AlunoId { get; set; }

    public Aluno Aluno { get; set; }

    public Pergunta Pergunta { get; set; }
}