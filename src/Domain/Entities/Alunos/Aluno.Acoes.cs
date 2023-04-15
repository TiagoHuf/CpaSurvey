namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno
{
    public void CorrigirNomeAluno(string nome)
    {
        Nome = nome;
    }

    public void CorrigirRaAluno(string ra)
    {
        Ra = ra;
    }

    public void Ativar()
    {
        IsAtivo = true;
    }

    public void Inativar()
    {
        IsAtivo = false;
    }
}