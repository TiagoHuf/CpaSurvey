using Biopark.CpaSurvey.Domain.Entities.Cursos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarCursoComSucesso()
    {
        var model = CursoFactory.GetCursoNovoModel();

        var curso = new Curso(model);

        curso.Should().NotBeNull();
        curso.Nome.Should().Be(model.Nome);
    }
}