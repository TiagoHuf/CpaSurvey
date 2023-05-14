using Biopark.CpaSurvey.Domain.Entities.Turmas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Turmas
{
    public partial class TurmaTests
    {
        private Turma _turma;

        [SetUp]
        public void TurmaTestsSetUp()
        {
            var model = TurmaFactory.GetTurmaNovaModel("Nova Turma");
            _turma = new Turma(model);
        }

        [Test]
        public void DeveCorrigirnomeComSucesso()
        {
            var NovoNome = "Novo Nome";

            _turma.CorrigirNome(NovoNome);

            _turma.Nome.Should().Be(NovoNome);
        }
    }
}
