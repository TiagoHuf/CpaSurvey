using Biopark.CpaSurvey.Domain.Entities.Eixos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Eixos;

public class EixoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarEixoComSucesso()
    {
        var model = EixoFactory.GetEixoNovoModel();

        var eixo = new Eixo(model);

        eixo.Should().NotBeNull();
        eixo.Nome.Should().Be(model.Nome);
        eixo.Descricao.Should().Be(model.Descricao);
    }
}