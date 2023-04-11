using Biopark.CpaSurvey.Domain.Entities.Cursos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public class CursoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarCursoaComSucesso()
    {
        var cursoNome = "Curso teste";
        var model = CursoFactory.GetCursoNovoModel(cursoNome);

        var curso = new Curso(model);

        curso.Should().NotBeNull();
        curso.Nome.Should().Be(model.Nome);
    }
}