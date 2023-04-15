using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Respostas;

namespace Biopark.CpaSurvey.Domain.Entities.Respostas;
public partial class Resposta : BaseEntity<long>, IAggregateRoot
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
    public string? Descricao { get; private set; }

    public int? Valor { get; private set; }

    public long PerguntaId { get; private set; }

    public long AlunoId { get; private set; }

    public Aluno Aluno { get; private set; }

    public Pergunta Pergunta { get; private set; }
}