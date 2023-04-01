using Biopark.CpaSurvey.Domain.Entities.Tipo;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.TiposArea;

public class TipoAreaTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarTipoAreaComSucesso()
    {
        var model = TipoAreaFactory.GetTipoAreaNovaModel();

        var tipoArea = new TipoArea(model);

        tipoArea.Should().NotBeNull();
        tipoArea.Nome.Should().Be(model.Nome);
    }
}