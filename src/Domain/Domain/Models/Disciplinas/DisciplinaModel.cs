namespace Biopark.CpaSurvey.Domain.Models.Disciplinas;

public class DisciplinaModel
{
    public string Nome { get; set; }

    public long ProfessorId { get; set; }

    public long CursoId { get; set; }
}