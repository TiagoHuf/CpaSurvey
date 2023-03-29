using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Respostas;

namespace Biopark.CpaSurvey.Domain.Entities.Respostas;
public class Resposta : BaseEntity<long>, IAggregateRoot
{
    public Resposta(RespostaModel model)
    {
        Descricao = model.Descricao;
        Valor = model.Valor;
        PerguntaId = model.PerguntaId;
        AlunoId = model.AlunoId;
        Aluno = model.Aluno;
        Pergunta = model.Pergunta;
    }

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