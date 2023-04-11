using Biopark.CpaSurvey.Domain.Entities.Turmas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Turmas;

public class TurmaTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarTurmaComSucesso()
    {
        var nomeTurma = "Turma teste";
        var model = TurmaFactory.GetTurmaNovaModel(nomeTurma);

        var turma = new Turma(model);

        turma.Should().NotBeNull();
        turma.Nome.Should().Be(nomeTurma);
        turma.CursoId.Should().Be(model.CursoId);
    }
}