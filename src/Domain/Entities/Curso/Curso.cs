using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Curso;

namespace Biopark.CpaSurvey.Domain.Entities.Cursos
{
    public class Curso : BaseEntity<long>, IAggregateRoot
    {
        public Curso(CursosModel model)
        {
            Nome = model.Nome;
        }

        private Curso()
        {
        }

        public string Nome { get; private set; }
    }
}
