using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public partial class AvaliacaoTest
{
    private Avaliacao _avaliacao;

    [SetUp]
    public void AvaliacaoTestsSetUp()
    {
        var model = AvaliacaoFactory.GetAvaliacaoNovaModel();
        _avaliacao = new Avaliacao(model);
    }

    [Test]
    public void DeveCorrigitNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _avaliacao.CorrigirNomeAvaliacao(novoNome);

        _avaliacao.Nome.Should().Be(novoNome);
    }

    [Test]
    public void DeveCorrigirDataInicioFimComSucesso()
    {
        var novaDataInicio = DateTime.Now;

        var novaDataFim = DateTime.Now;

        _avaliacao.CorrigirDataAvaliacao(novaDataFim);

        _avaliacao.DataFim.Should().Be(novaDataFim);

    }

}