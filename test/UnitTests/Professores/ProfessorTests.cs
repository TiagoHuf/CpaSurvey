using Biopark.CpaSurvey.Domain.Entities.Professores;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Professores;

public partial class ProfessorTests: TestBase
{
    [Test]
    public void ConstrutorDeveCriarProfessorComSucesso()
    {
        var model = ProfessorFactory.GetProfessorNovoModel();

        var professor = new Professor(model);

        professor.Should().NotBeNull();
        professor.Nome.Should().Be(model.Nome);  
    }
}