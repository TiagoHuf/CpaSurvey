using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public class AvaliacaoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarTurmaComSucesso()
    {
        var model = AvaliacaoFactory.GetAvaliacaoNovaModel();

        var avaliacao = new Avaliacao(model);

        avaliacao.Should().NotBeNull();
        avaliacao.Nome.Should().Be(model.Nome);
        avaliacao.DataInicio.Should().Be(model.DataInicio);
        avaliacao.DataFim.Should().Be(model.DataFim);
        //avaliacao.Cursos.Should().HaveCount(model.Cursos.Count);
        avaliacao.Turmas.Should().HaveCount(model.Turmas.Count);
    }
}