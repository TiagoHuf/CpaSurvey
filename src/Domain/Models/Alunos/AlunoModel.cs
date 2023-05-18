using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Entities.Turmas;

namespace Biopark.CpaSurvey.Domain.Models.Alunos;

public class AlunoModel
{
    public string Nome { get; set; }

    public string Ra { get; set; }

    public string Email { get; set; }

    public long CursoId { get; set; }
}