
using Biopark.CpaSurvey.Domain.Entities.Professores;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Professores;

public partial class ProfessorTests
{
    private Professor _professor;

    [SetUp]
    public void ProfessorTestsSetUp()
    {
        var model = ProfessorFactory.GetProfessorNovoModel();
        _professor = new Professor(model);
    }

    [Test]
    public void CorrigirNomeComSucesso()
    {
        var novoNome = "Novo Professor";

        _professor.CorrigirNome(novoNome);

        _professor.Nome.Should().Be(novoNome);
    }
}