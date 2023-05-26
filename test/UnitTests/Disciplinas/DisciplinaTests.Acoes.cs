
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public partial class DisciplinaTests
{
    private Disciplina _disciplina;

    [SetUp]
    public void DisciplinaTestsSetUp()
    {
        var model = DisciplinaFactory.GetDisciplinaNovoModel("Nova Disciplina");
        _disciplina = new Disciplina(model);
    }

    [Test]
    public void DeveCorrigirNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _disciplina.CorrigirNome(novoNome);

        _disciplina.Nome.Should().Be(novoNome);
    }
}