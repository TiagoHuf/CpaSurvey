using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public partial class DisciplinaTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarDisciplinaComSucesso()
    {
        var model = DisciplinaFactory.GetDisciplinaNovoModel();

        var disciplina = new Disciplina(model);

        disciplina.Should().NotBeNull();
        disciplina.Nome.Should().Be(model.Nome);
    }
}