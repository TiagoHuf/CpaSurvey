namespace Biopark.CpaSurvey.Domain.Entities.Cursos;

public partial class Curso
{
    public void CorrigirNome(string nome)
    {
        Nome = nome;
    }
}