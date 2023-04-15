namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno
{
    private void CorrigirNomeAluno(string nome)
    {
        Nome = nome;
    }

    private void CorrigirRaAluno(string ra)
    {
        Ra = ra;
    }

    private void Ativar()
    {
        IsAtivo = true;
    }

    private void Inativar()
    {
        IsAtivo = false;
    }
}