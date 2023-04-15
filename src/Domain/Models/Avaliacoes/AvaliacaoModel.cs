using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Entities.Cursos;

namespace Biopark.CpaSurvey.Domain.Models.Avaliacoes;

public class AvaliacaoModel
{
    public string Nome { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    //public List<Curso> Cursos { get; set; }

    public List<Turma> Turmas { get; set; }

    //public long CursoId { get; set; }

    public long TurmaId { get; set; }
}