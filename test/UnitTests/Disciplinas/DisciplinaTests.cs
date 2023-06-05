using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Disciplinas;

public partial class DisciplinaTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarDisciplinaComSucesso()
    {
        var nomeDisciplina = "Disciplina Teste";
        var model = DisciplinaFactory.GetDisciplinaNovaModel(nomeDisciplina);

        var disciplina = new Disciplina(model);

        disciplina.Should().NotBeNull();
        disciplina.Nome.Should().Be(model.Nome);
        disciplina.ProfessorId.Should().Be(model.ProfessorId);
        disciplina.CursoId.Should().Be(model.CursoId);
    }
}