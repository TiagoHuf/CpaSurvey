using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Curso;

namespace Biopark.CpaSurvey.Domain.Entities.Cursos
{
    public class Cursos : BaseEntity<long>, IAggregateRoot
    {
        public Cursos(CursosModel model)
        {
            Nome = model.Nome;
        }

        private Cursos()
        {
        }

        public string Nome { get; private set; }
    }
}
