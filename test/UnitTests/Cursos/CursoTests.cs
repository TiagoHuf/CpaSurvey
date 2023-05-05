using Biopark.CpaSurvey.Domain.Entities.Cursos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarCursoaComSucesso()
    {
        var nome = "Curso Test";
        var model = CursoFactory.GetCursoNovoModel(nome);

        var curso = new Curso(model);

        curso.Should().NotBeNull();
        curso.Nome.Should().Be(model.Nome);
    }
}