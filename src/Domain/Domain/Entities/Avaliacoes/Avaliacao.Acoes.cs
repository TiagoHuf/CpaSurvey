using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Entities.Avaliacoes;

public partial class Avaliacao
{
    public void CorrigirNomeAvaliacao(string nome)
    {
        Nome = nome;
    }

    public void CorrigirDataAvaliacao(DateTime fim)
    {
        DataFim = fim;
    }

    public void AdicionarPergunta(Pergunta pergunta)
    {
        _perguntas.Add(pergunta);
    }

    public void RemoverPergunta(Pergunta pergunta)
    {
        _perguntas.Remove(pergunta);
    }  

    public void AdicionarTurma(Turma turma)
    {
        _turmas.Add(turma);
    }

    public void RemoverTurma(Turma turma)
    {
        _turmas.Remove(turma);
    }
}