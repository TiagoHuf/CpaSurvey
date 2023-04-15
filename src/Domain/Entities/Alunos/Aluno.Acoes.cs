namespace Biopark.CpaSurvey.Domain.Entities.Alunos;

public partial class Aluno
{
    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }

    public void CorrigirRa(string ra)
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